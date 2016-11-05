/*
 * Authors: Joseph Gillen, Isaiah Mann, Kevin Wang
 * Initial Date: 20th October 2016
 * Description: This class spawns the contacts
 */

using UnityEngine;
using System.Collections;

public class ContactScreen : LScreenController {
	LCharacterController character;
	LMessengerAppController messengerApp;

    public GameObject Contact;
	public float ContactSize = 2;

	// I have redeemed their hard coded souls - Isaiah
	LContactGroup contacts;

	protected override void SetReferences () {
		base.SetReferences ();
		messengerApp = GetComponentInParent<LMessengerAppController>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		character = LCharacterController.Instance;
		contacts = character.IContacts;
		InstantiateContactGroup(contacts);
		if (!LMessenger.first) {
			Contact current = LMessenger.currentOpen;
			if (LMessenger.isContactsOpen)
				messengerApp.switchToContacts ();
			else {
				messengerApp.switchToMessages (current);
			}
		}
		if (LMessenger.first) {
			messengerApp.switchToContacts ();
		}
	}
		
	void InstantiateContactGroup (LContactGroup group) {
		foreach (LContact contact in group.Elements) {
			InstatiateContact(contact);
		}
	}
		
	void InstatiateContact(LContact contact) {
        // Create a contact with the above information
		GameObject aContact = Instantiate(Contact, new Vector3(0f,0f,0f), Quaternion.identity) as GameObject;

		aContact.transform.SetParent (gameObject.transform);
        aContact.GetComponent<Contact>().AssignNameAndImage();
		aContact.GetComponent<Contact>().CreateContact(contact, ContactSize);
    }
}
