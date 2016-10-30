/*
 * Authors: Joseph Gillen, Isaiah Mann
 * Initial Date: 20th October 2016
 * Description: This class spawns the contacts
 */

using UnityEngine;
using System.Collections;

public class ContactScreen : LScreenController {
	LCharacterController character;
    public GameObject Contact;
    public Vector3 spawnPosition;
	public float YOffset = -85;
	public float ContactYSpacing = 40;
	public float ContactSize = 2;

	// I have redeemed their hard coded souls - Isaiah
	LContactGroup contacts;

	protected override void SetReferences () {
		base.SetReferences ();
		Vector3 temp = gameObject.transform.position;
		temp.y = temp.y * -1;
		spawnPosition = Vector3.down * YOffset + temp/ContactSize;
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		character = LCharacterController.Instance;
		contacts = character.IContacts;
		InstantiateContactGroup(contacts);
	}
		
	void InstantiateContactGroup (LContactGroup group) {
		foreach (LContact contact in group.Elements) {
			InstatiateContact(contact);
		}
	}
		
	void InstatiateContact(LContact contact) {
        // Create a contact with the above information
        GameObject aContact = Instantiate(Contact, spawnPosition, Quaternion.identity) as GameObject;
		//Debug.Log ("spawn position: " + spawnPosition);
		//Debug.Log ("contact position: " + aContact.transform.position);
		spawnPosition.y -= ContactYSpacing;

		aContact.transform.SetParent (gameObject.transform);
		//aContact.transform.Translate (aContact.transform.position);
        aContact.GetComponent<Contact>().AssignNameAndImage();
		aContact.GetComponent<Contact>().CreateContact(contact, ContactSize);
    }
}
