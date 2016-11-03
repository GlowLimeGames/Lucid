/*
 * Created by: Kevin Wang
 * Description: Used to manage the display of objects on the messaging screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LMessengerAppController : LScreenController {

	public static bool isContactsOpen = true;
	//the GameObjects to switch between the contact list and message panel
	public GameObject contactList;
	public GameObject messagePanel;
	public Contact currentContact;

	public Image NPC;

	public void LoadMessageUI(Contact contact){
		contact.getContact ().BoolIsMessageUnread = false;
		switchToMessages (contact);
	}

	public void switchToMessages(Contact contact){
		//Debug.Log ("switchToMessages");
		contactList.SetActive (false);
		messagePanel.SetActive (true);
		initializeMessagePanel (contact);
		currentContact = contact;
		isContactsOpen = false;
	}

	public void switchToContacts(){
		//Debug.Log ("switchToContacts");
		contactList.SetActive (true);
		messagePanel.SetActive (false);
		isContactsOpen = true;
	}

	public void initializeMessagePanel(Contact contact){
		//NPC = contact.GetComponentInChildren<Image>();
	}
}
