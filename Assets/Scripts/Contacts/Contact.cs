/*
 * Authors: Joseph Gillen, Kevin Wang, Isaiah Mann
 * Initial Date: 20th October 2016
 * Description: This class is used to show contact details on contact screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Contact : LUIElement {
	[SerializeField]
	Text messageSnippet;

	public int snippetLength = 100;

	LDataController data;
	LStoryController story;
	bool hasRunInit = false;
	LMessengerScreenController controller;
	NotificationHighlight highlight;
	Image contactImageDisplay;
	Transform contactImageMask;
	Text contactNameDisplay;
    private GameObject ContactImage, ContactName, UnreadMessageCount;

    LContact instanceOfContact = new LContact();
	public LConversation conversation;

	public Sprite ContactSprite {
		get {	
			return instanceOfContact.SpriteContactImage;
		}
	}

    // For each contact call the contact creation method
    // Temporary function for hard coded values
	public LContact CreateContact(LDataController data, LStoryController story, LContact contact, float scale = 1f) {
		this.data = data;
		this.story = story;
		if (this.story.TryLoadConversation(contact.Name, out conversation) || (conversation != null && !conversation.HasBegun)) {
			checkToDisplayMostRecentMessageSnippet();
		} else {
			conversation = new LConversation(contact.Name, contact, story.Player);
			this.story.TrackConversation(conversation);
		}
		checkToRunInit();
        instanceOfContact.ContactID = contact.ContactID;
        instanceOfContact.ContactName = contact.ContactName;
        instanceOfContact.NumberOfMessagesRecieved = contact.NumberOfMessagesRecieved;
        instanceOfContact.NumberOfMessagesSent = contact.NumberOfMessagesSent;
        instanceOfContact.SpriteContactImage = contact.SpriteContactImage;
		instanceOfContact.BoolIsMessageUnread = contact.BoolIsMessageUnread;
        instanceOfContact.BoolIsContact = contact.BoolIsContact;
        AssignNameAndImage();
		transform.localScale = new Vector3(scale, scale, scale);
		Vector3 inverseScale = new Vector3(1f / scale, 1f / scale, 1f / scale);
		ContactImage.transform.localScale = inverseScale;
		ContactName.transform.localScale = inverseScale;
		UnreadMessageCount.transform.localScale = inverseScale;
		messageSnippet.transform.localScale = inverseScale;

		//sets the size of the contact boxes
		RectTransform current = GetComponent<RectTransform> ();
		RectTransform canvasSize = current.parent.parent.GetComponent<RectTransform> ();
		float h = canvasSize.rect.height;
		float w = canvasSize.rect.width;
		LayoutElement layout = GetComponent<LayoutElement> ();
		layout.minHeight = h/ (scale * 7);
		layout.preferredHeight = h/ (scale * 7);
		layout.minWidth = w / scale;
		layout.preferredWidth= w / scale;

		/*ContactImage = transform.GetChild(0).gameObject;
		ContactName = transform.GetChild(1).gameObject;
		UnreadMessageCount = transform.GetChild(2).gameObject;
		contactImageMask = ContactImage.GetComponentInChildren<Mask> ().transform;
		contactImageDisplay = contactImageMask.GetChild(0).GetComponent<Image>();
		contactNameDisplay = ContactName.GetComponent<Text>();*/
		RectTransform maskRect = contactImageMask.GetComponent<RectTransform> ();
		maskRect.anchorMin = new Vector2 (0.15f, 0.5f);
		maskRect.anchorMax = new Vector2 (0.15f, 0.5f);

		RectTransform snipRect = messageSnippet.gameObject.GetComponent<RectTransform> ();
		snipRect.anchorMin = new Vector2 (0.65f, 0.35f);
		snipRect.anchorMax = new Vector2 (0.65f, 0.35f);


		GetComponentInParent<VerticalLayoutGroup> ().spacing = h/ (scale*3);

        return instanceOfContact;
    }

	bool checkToDisplayMostRecentMessageSnippet () {
		if (conversation.HasBegun) {
			string newSnip = conversation.GetLastMessage();
			messageSnippet.text = newSnip.Length > snippetLength ? newSnip.Substring (0, snippetLength) + "..." : newSnip;
			return true;
		} else {
			return false;
		}
	}

    // Giving the contact a name and image
    public void AssignNameAndImage()
    {
		checkToRunInit();
		contactImageDisplay.sprite = instanceOfContact.SpriteContactImage;
		contactNameDisplay.text = instanceOfContact.ContactName;
		if (instanceOfContact.BoolIsMessageUnread)
			highlight.toggleHighlight ();

    }
    // Trigger Message Loading
    public void LoadMessageUI() {
		controller.LoadMessageUI (this);
    }

	public LContact getContact(){
		return instanceOfContact;
	}

	public void AddMessage (LText message){
		conversation.AddMessage (message);
		data.Save();
	}

	public static bool operator == (Contact first,Contact second){
		return (first.ContactName == second.ContactName);
	}

	public static bool operator != (Contact first, Contact second){
		return !(first.ContactName == second.ContactName);
	}

	public override bool Equals (object o) {
		return this == o as Contact;
	}

	public override int GetHashCode () {
		return ContactName.GetHashCode ();
	}

	public override string ToString(){
		string s = instanceOfContact.ContactName;
		s+="\n"+instanceOfContact.ContactID;
		s += "\n" + instanceOfContact.BoolIsMessageUnread;
		return s;
	}

	public void Refresh () {
		checkToDisplayMostRecentMessageSnippet();
	}

	void checkToRunInit () {
		if (!hasRunInit) {
			runInit();
		}
	}

	void runInit () {
		controller = GetComponentInParent<LMessengerScreenController>();
		highlight = GetComponent<NotificationHighlight>();
		ContactImage = transform.GetChild(0).gameObject;
		ContactName = transform.GetChild(1).gameObject;
		UnreadMessageCount = transform.GetChild(2).gameObject;
		contactImageMask = ContactImage.GetComponentInChildren<Mask> ().transform;
		contactImageDisplay = contactImageMask.GetChild(0).GetComponent<Image>();
		contactNameDisplay = ContactName.GetComponent<Text>();
	}

	#region MannBehaviour Protocol

	protected override void SetReferences () {
		base.SetReferences ();
		checkToRunInit();
	}

	#endregion
}
