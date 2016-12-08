/*
 * Author(s): Kevin Wang, Isaiah Mann
 * Description: Controller for the messenger screen
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LMessengerScreenController : LScreenController {
	public float NPCResponseDelay = 1.0f;
	public static bool isContactsOpen = true;
	//the GameObjects to switch between the contact list and message panel
	[SerializeField]
	GameObject contactList;
	[SerializeField]
	GameObject messagePanel;
	[SerializeField]
	Contact currentContact;
	LConversationGraph currentConversation;
	LText mostRecentMessage;
	GameObject theMessage;
	public Image NPC;
	Contact[] allContacts;

	[SerializeField]
	GameObject npcTextPrefab;
	[SerializeField]
	GameObject playerTextPrefab;
	[SerializeField]
	Transform messageParent;

	[SerializeField]
	GameObject messageScrollView;
	[SerializeField]
	GameObject scrollBar;

	List<LTextBehaviour> visualTexts = new List<LTextBehaviour>();

	SetVerticalPosition scrollPosition;

	#region App Title

	// Set this on init
	string defaultTitle;
	[SerializeField]
	Text appTitle;

	#endregion

	/****************************divider******************************/



	// The data source that accesses all texting
	protected LMessageController messaging;
	protected LTextingResponder responder;

	protected override void SetReferences () {
		base.SetReferences ();
		responder = GetComponentInChildren<LTextingResponder>(true);
		scrollPosition = GetComponentInChildren<SetVerticalPosition> (true);
		float size = messageScrollView.GetComponent<RectTransform> ().rect.height;
		scrollPosition.setWindowSize (size);
		scrollPosition.setOffset (responder.PanelSize);
		defaultTitle = appTitle.text;
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		messaging = LMessageController.Instance;
		init();
		allContacts = contactList.GetComponentsInChildren<Contact>();
	}

	public new void LoadHome(){
		bool contacts = LMessengerScreenController.isContactsOpen;

		Contact[] list = GetComponentsInChildren<Contact> (true);
		bool[] notes = new bool[list.Length];
		LConversation[] convs = new LConversation[list.Length];
		int i = 0;
		foreach (Contact c in list) {
			LContact lc = c.getContact();
			notes [i] = lc.BoolIsMessageUnread;
			convs [i] = c.conversation;
			i++;
		}
		LMessenger.set (contacts, notes, convs, currentContact);
		//LMessenger.first = false;
		base.LoadHome ();
	}

	// Can accept an arbitrary number or an array of LTexts and create them in order
	public void AddTexts (bool newTexts = true, params LText[] texts) {
		foreach (LText text in texts) {
			AddText(text, newTexts);	
		}
	}

	// Adds a visual text to the screen using an LText as the data source
	public LTextBehaviour AddText (LText text, bool newText = true) {
		checkTextScrollView();
		GameObject prefab = text.FromPlayer ? playerTextPrefab : npcTextPrefab;
		GameObject textObject = Instantiate(prefab, messageParent) as GameObject;
		Transform textTransform = textObject.transform;
		textTransform.localScale = Vector3.one;
		LTextBehaviour textBehaviour = textObject.GetComponent<LTextBehaviour>();
		textBehaviour.SetText(text.Body);
		textBehaviour.SetImage(currentContact.ContactSprite);
		visualTexts.Add(textBehaviour);
		mostRecentMessage = text;
		theMessage = textObject;
		if (newText) {
			currentContact.AddMessage(text);
		}
		scrollPosition.addText (theMessage);
		return textBehaviour;
	}

	public void ClearAllTexts () {
		for (int i = 0; i < visualTexts.Count; i++) {
			Destroy(visualTexts[i].gameObject);
		}
		visualTexts.Clear();
	}

	public void SendText (LText text) {
		AddText(text);
		HideResponsePanel ();
		LText response = currentConversation.ChooseResponse(mostRecentMessage);
		if (response != null) {
			StartCoroutine(NPCRespondDelayed(response));
		} else {
			currentContact.conversation.MarkAsComplete();
		}
	}

	IEnumerator NPCRespondDelayed (LText response) {
		yield return new WaitForSeconds(NPCResponseDelay);
		EventController.Event(LEvent.Message);
		AddText(response);
		DisplayResponses(mostRecentMessage);
	}

	public void DisplayResponses (LText text) {
		LText[] responses = currentConversation.GetResponses(text);
		if (responses != null) {
			responder.SetResponses(responses);
		}
	}

	public void HideResponsePanel () {
		responder.Hide();
		RectTransform scrollRect = scrollBar.GetComponent<RectTransform> ();
		scrollRect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, messageScrollView.GetComponent<RectTransform> ().rect.height);
	}

	public void HideResponses () {
		responder.ToggleResponses(false);
	}

	public void BackButton(){
		if (isContactsOpen)
			LoadHome ();
		else
			switchToContacts ();
	}

	public void changeOffset(float f){
		scrollPosition.setOffset (f);
	}



	/****************************divider******************************/



	public void LoadMessageUI(Contact contact){
		contact.getContact ().BoolIsMessageUnread = false;
		switchToMessages (contact);
	}

	public void switchToMessages(Contact contact){
		setAppTitle(contact);
		messageScrollView.SetActive(true);
		contactList.SetActive (false);
		messagePanel.SetActive (true);
		initializeMessagePanel (contact);
		currentContact = contact;
		isContactsOpen = false;
		currentConversation = messaging.GetConversation(contact.getContact());
		if (currentConversation != null) {
			ClearAllTexts();
			AddTexts(false, contact.conversation.messages.ToArray());
			if (!contact.conversation.HasBegun) {
				AddText(currentConversation.GetFirstMessage().Value);
			}
			if (mostRecentMessage != null && mostRecentMessage.Responses != null && mostRecentMessage.Responses.Length > 0) {
				DisplayResponses(mostRecentMessage);
			}
		}
	}

	public void switchToContacts(){
		refreshContacts();
		resetAppTitle();
		contactList.SetActive (true);
		messagePanel.SetActive (false);
		isContactsOpen = true;
		messageScrollView.SetActive(false);
		ClearAllTexts();
		HideResponses();
	}

	//code for retaining the messages in the panel
	public void initializeMessagePanel(Contact contact){
		//NPC = contact.GetComponentInChildren<Image>();
	}

	// Overloaded method to set directly from a contact object
	void setAppTitle (Contact contact) {
		setAppTitle(contact.getContact().ContactName);
	}

	void setAppTitle (string title) {
		appTitle.text = title;
	}

	void resetAppTitle () {
		setAppTitle(defaultTitle);
	}

	void refreshContacts () {
		if (allContacts != null) {
			foreach (Contact c in allContacts) {
				c.Refresh();
			}
		}
	}

	void checkTextScrollView () {
		if (!messageScrollView.activeSelf) {
			messageScrollView.SetActive(true);
		}
	}

	void init () {
		if (!LMessenger.first) {
			Contact current = LMessenger.currentOpen;
			if (isContactsOpen)
				switchToContacts ();
			else {
				switchToMessages (current);
			}
		}
		if (LMessenger.first) {
			switchToContacts ();
		}
	}
}
