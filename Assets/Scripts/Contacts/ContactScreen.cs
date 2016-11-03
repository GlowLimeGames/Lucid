/*
 * Authors: Joseph Gillen, Isaiah Mann, Kevin Wang
 * Initial Date: 20th October 2016
 * Description: This class spawns the contacts
 */

using UnityEngine;
using System.Collections;

public class ContactScreen : LScreenController {
	LCharacterController character;
    public GameObject Contact;
	public float ContactSize = 2;

	// I have redeemed their hard coded souls - Isaiah
	LContactGroup contacts;

	protected override void SetReferences () {
		base.SetReferences ();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		character = LCharacterController.Instance;
		contacts = character.IContacts;
		InstantiateContactGroup(contacts);
		if (!LMessenger.first) {
			Debug.Log ("!first");
			if (!LMessenger.isContactsOpen) {
				Debug.Log ("!LMessenger.isContactsOpen");
				Contact[] list = GetComponentsInChildren<Contact> ();
				Contact current = LMessenger.currentOpen;
				/*
				foreach (Contact c in list) {
					if (c == LMessenger.currentOpen) {
						Debug.Log ("123");
						current = c;
						break;
					}
				}
				*/
				GetComponentInParent<LMessengerAppController> ().switchToMessages (current);
			}
			LMessenger.first = false;
		} else
			GetComponentInParent<LMessengerAppController> ().switchToContacts ();
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
