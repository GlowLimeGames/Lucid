/*
 * Author: Joseph Gillen
 * Initial Date: 20th October 2016
 * Description: This class is used to show contact details on contact screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Contact : MonoBehaviour {

    private GameObject ContactImage, ContactName;
    LContact instanceOfContact = new LContact();
    // For each contact call the contact creation method
    // Temperary function for hard coded values
    public LContact CreateContact(LContact contact)
    {
        instanceOfContact.ContactID = contact.ContactID;
        instanceOfContact.ContactName = contact.ContactName;
        instanceOfContact.NumberOfMessagesRecieved = contact.NumberOfMessagesRecieved;
        instanceOfContact.NumberOfMessagsSent = contact.NumberOfMessagsSent;
        instanceOfContact.SpriteContactImage = contact.SpriteContactImage;
        instanceOfContact.BoolIsMessageUnread = contact.BoolIsMessageUnread;
        instanceOfContact.BoolIsContact = contact.BoolIsContact;
        Debug.Log(ContactImage.name);
        AssignNameAndImage();
        return instanceOfContact;
    }
    // Giving the contact a name and image
    public void AssignNameAndImage()
    {
        ContactImage = gameObject.transform.GetChild(0).gameObject;
        ContactName = gameObject.transform.GetChild(1).gameObject;
        ContactImage.GetComponent<Image>().sprite = instanceOfContact.SpriteContactImage;
        ContactName.GetComponent<Text>().text = instanceOfContact.ContactName;
    }
    // Trigger Message Loading
    public void LoadMessageUI()
    {
        Debug.Log("Ohh wee look at me");
    }
}
