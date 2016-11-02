/*
 * Created by: Kevin Wang
 * Description: Used to manage the display of objects on the messaging screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LMessengerAppController : LScreenController {

	public static bool isContactsOpen;
	//the GameObjects to switch between the contact list and message panel
	public GameObject contactList;
	public GameObject messagePanel;
	public Contact currentContact;

	void Start(){
		isContactsOpen = true;
		contactList.SetActive (true);
		messagePanel.SetActive (false);
	}

	public void LoadMessageUI(Contact contact){
		contact.getCurrentContact ().BoolIsMessageUnread = false;
		switchContactsMessages (contact);
	}

	public void switchContactsMessages(Contact contact){
		Debug.Log ("2");
		if (isContactsOpen) {
			contactList.SetActive (false);
			messagePanel.SetActive (true);
			initializeMessagePanel (contact);
			currentContact = contact;
			isContactsOpen = false;
		} else
			switchToContacts ();
	}

	public void switchToContacts(){
		if (!isContactsOpen) {
			contactList.SetActive (true);
			messagePanel.SetActive (false);
		}
		isContactsOpen = true;
	}

	public void initializeMessagePanel(Contact contact){

	}
}
