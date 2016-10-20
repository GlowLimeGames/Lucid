/*
 * Author: Joseph Gillen
 * Initial Date: 20th October 2016
 * Description: This class spawns the contacts
 */

using UnityEngine;
using System.Collections;

public class ContactScreen : MonoBehaviour {

    public GameObject Contact;
    public Vector3 spawnPosition;
    // HARD CODED HORROR
    LContact[] arrayOfContacts = new LContact[3];
	// Use this for initialization
	void Start () {
        spawnPosition = gameObject.transform.position;
        // HARD CODED HORROR
        for (int i = 0; i < 3; i++)
        {
            arrayOfContacts[i] = new LContact();
            arrayOfContacts[i].ContactID = "0" + i;
            arrayOfContacts[i].ContactName = "Name" + i;
            arrayOfContacts[i].NumberOfMessagesRecieved = 0;
            arrayOfContacts[i].NumberOfMessagsSent = 0;
            arrayOfContacts[i].SpriteContactImage = null;
            arrayOfContacts[i].BoolIsMessageUnread = false;
            arrayOfContacts[i].BoolIsContact = true;
        }
        // HARD CODED HORROR
        for (int i = 0; i < 3; i++)
        {
            InstatiateContact(i);
            spawnPosition.y -= 50;
        }
    }
    void InstatiateContact(int i)
    {
        // Create a contact with the above information
        GameObject aContact = Instantiate(Contact, spawnPosition, Quaternion.identity) as GameObject;
        aContact.transform.parent = gameObject.transform;
        aContact.GetComponent<Contact>().AssignNameAndImage();
        aContact.GetComponent<Contact>().CreateContact(arrayOfContacts[i]);
    }
}
