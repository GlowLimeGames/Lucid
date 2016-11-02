/*
 * Author: Joseph Gillen, Kevin Wang
 * Initial Date: 20th October 2016
 * Description: This class is used to show contact details on contact screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Contact : MonoBehaviour {

    private GameObject ContactImage, ContactName, UnreadMessageCount;

    LContact instanceOfContact = new LContact();
	public LConversation conversation;

    // For each contact call the contact creation method
    // Temporary function for hard coded values
	public LContact CreateContact(LContact contact, float scale = 1f)
    {
        instanceOfContact.ContactID = contact.ContactID;
        instanceOfContact.ContactName = contact.ContactName;
        instanceOfContact.NumberOfMessagesRecieved = contact.NumberOfMessagesRecieved;
        instanceOfContact.NumberOfMessagesSent = contact.NumberOfMessagesSent;
        instanceOfContact.SpriteContactImage = contact.SpriteContactImage;
		instanceOfContact.BoolIsMessageUnread = true;//contact.BoolIsMessageUnread;
        instanceOfContact.BoolIsContact = contact.BoolIsContact;
        AssignNameAndImage();
		transform.localScale = new Vector3(scale, scale, scale);
		Vector3 inverseScale = new Vector3(1f / scale, 1f / scale, 1f / scale);
		ContactName.transform.localScale = inverseScale;
		UnreadMessageCount.transform.localScale = inverseScale;

		//sets the size of the contact boxes
		RectTransform current = GetComponent<RectTransform> ();
		RectTransform canvasSize = current.parent.parent.GetComponent<RectTransform> ();
		float h = canvasSize.rect.height;
		float w = canvasSize.rect.width;

		LayoutElement layout = GetComponent<LayoutElement> ();
		layout.minHeight = h / (scale * 5);
		layout.preferredHeight = h / (scale * 5);
		layout.minWidth = w / scale;
		layout.preferredWidth= w / scale;

		GetComponentInParent<VerticalLayoutGroup> ().spacing = (0.3f * h )/ scale;

        return instanceOfContact;
    }
    // Giving the contact a name and image
    public void AssignNameAndImage()
    {
        ContactImage = transform.GetChild(0).gameObject;
        ContactName = transform.GetChild(1).gameObject;
		UnreadMessageCount = transform.GetChild(2).gameObject;
        ContactImage.GetComponent<Image>().sprite = instanceOfContact.SpriteContactImage;
        ContactName.GetComponent<Text>().text = instanceOfContact.ContactName;
		if (instanceOfContact.BoolIsMessageUnread)
			GetComponent<NotificationHighlight> ().toggleHighlight ();

    }
    // Trigger Message Loading
    public void LoadMessageUI()
    {
		transform.parent.transform.parent.GetComponent<LMessengerAppController>().LoadMessageUI (this);
    }

	public LContact getCurrentContact(){
		return instanceOfContact;
	}

	public void addMessage(LText message){
		conversation.addMessage (message);
	}
}
