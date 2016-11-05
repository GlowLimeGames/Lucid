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
	public Image NPC;


	[SerializeField]
	GameObject npcTextPrefab;
	[SerializeField]
	GameObject playerTextPrefab;
	[SerializeField]
	Transform messageParent;

	[SerializeField]
	GameObject messageScrollView;

	List<LTextBehaviour> visualTexts = new List<LTextBehaviour>();

	// The data source that accesses all texting
	protected LMessageController messaging;
	protected LTextingResponder responder;

	protected override void SetReferences () {
		base.SetReferences ();
		responder = GetComponentInChildren<LTextingResponder>(true);
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		messaging = LMessageController.Instance;
	}

	public new void LoadHome(){
		//Debug.Log ("LoadHome");
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
	public void AddTexts (params LText[] texts) {
		foreach (LText text in texts) {
			AddText(text);	
		}
	}

	// Adds a visual text to the screen using an LText as the data source
	public LTextBehaviour AddText (LText text) {
		checkTextScrollView();
		GameObject prefab = text.FromPlayer ? playerTextPrefab : npcTextPrefab;
		GameObject textObject = Instantiate(prefab, messageParent) as GameObject;
		Transform textTransform = textObject.transform;
		textTransform.localScale = Vector3.one;
		LTextBehaviour textBehaviour = textObject.GetComponent<LTextBehaviour>();
		textBehaviour.SetText(text.Body);
		visualTexts.Add(textBehaviour);
		mostRecentMessage = text;
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
		HideResponsePanel();
		LText response = currentConversation.ChooseResponse(mostRecentMessage);
		if (response != null) {
			StartCoroutine(NPCRespondDelayed(response));
		}
	}

	IEnumerator NPCRespondDelayed (LText response) {
		yield return new WaitForSeconds(NPCResponseDelay);
		AddText(response);
		DisplayResponses(mostRecentMessage);
	}

	public void DisplayResponses (LText text) {
		responder.SetResponses(currentConversation.GetResponses(text));
	}

	public void HideResponsePanel () {
		responder.Hide();
	}

	public void LoadMessageUI(Contact contact){
		contact.getContact ().BoolIsMessageUnread = false;
		switchToMessages (contact);
	}

	public void switchToMessages(Contact contact){
		contactList.SetActive (false);
		messagePanel.SetActive (true);
		initializeMessagePanel (contact);
		currentContact = contact;
		isContactsOpen = false;
		currentConversation = messaging.GetConversation(contact.getContact());
		if (currentConversation != null) {
			ClearAllTexts();
			AddText((currentConversation.GetFirstMessage()).Value);
			DisplayResponses(mostRecentMessage);
		}
	}

	public void switchToContacts(){
		contactList.SetActive (true);
		messagePanel.SetActive (false);
		isContactsOpen = true;
	}

	public void initializeMessagePanel(Contact contact){
		//NPC = contact.GetComponentInChildren<Image>();
	}

	void checkTextScrollView () {
		if (!messageScrollView.activeSelf) {
			messageScrollView.SetActive(true);
		}
	}
}
