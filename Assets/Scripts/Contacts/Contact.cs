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
	private LContact currentContact;

    LContact instanceOfContact = new LContact();
    // For each contact call the contact creation method
    // Temporary function for hard coded values
	public LContact CreateContact(LContact contact, float scale = 1f)
    {
        instanceOfContact.ContactID = contact.ContactID;
        instanceOfContact.ContactName = contact.ContactName;
        instanceOfContact.NumberOfMessagesRecieved = contact.NumberOfMessagesRecieved;
        instanceOfContact.NumberOfMessagsSent = contact.NumberOfMessagsSent;
        instanceOfContact.SpriteContactImage = contact.SpriteContactImage;
        instanceOfContact.BoolIsMessageUnread = contact.BoolIsMessageUnread;
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
		current.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, 65f);
		current.SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, w/scale-10);

		current.transform.Translate (new Vector3(-current.rect.width/4,0,0));

		currentContact = contact;

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
    }
    // Trigger Message Loading
    public void LoadMessageUI()
    {
		transform.parent.transform.parent.GetComponent<LMessengerAppController>().LoadMessageUI (currentContact);
    }
}
