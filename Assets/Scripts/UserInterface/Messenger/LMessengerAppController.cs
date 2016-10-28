using UnityEngine;
using System.Collections;

public class LMessengerAppController : LScreenController {

	public static bool isContactsOpen;
	public GameObject contactList;
	public GameObject messagePanel;

	void Start(){
		isContactsOpen = true;
		contactList.SetActive (true);
		messagePanel.SetActive (false);
	}

	public void LoadMessageUI(LContact contact){
		Debug.Log("Things happened");
		switchContactsMessages (contact);
	}

	public void switchContactsMessages(LContact contact){
		if (isContactsOpen) {
			contactList.SetActive (false);
			messagePanel.SetActive (true);
			initializeMessagePanel (contact);
		} else {
			contactList.SetActive (true);
			messagePanel.SetActive (false);
		}
		isContactsOpen = !isContactsOpen;
	}

	public void initializeMessagePanel(LContact contact){

	}
}
