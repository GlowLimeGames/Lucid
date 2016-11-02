/*
 * Author(s): Kevin Wang
 * Description: Controller for the messenger screen
 */

using UnityEngine;
using System.Collections;

public class LMessengerScreenController : LScreenController {

	public void LoadHome(){
		Debug.Log ("3");
		bool contacts = LMessengerAppController.isContactsOpen;

		Contact[] list = GetComponentsInChildren<Contact> ();
		bool[] notes = new bool[list.Length];
		LConversation[] convs = new LConversation[list.Length];
		int i = 0;
		foreach (Contact c in list) {
			LContact lc = c.getCurrentContact();
			notes [i] = lc.BoolIsMessageUnread;
			convs [i] = c.conversation;
			i++;
		}
		LMessenger.set (contacts, notes, convs, GetComponentInChildren<LMessengerAppController> ().currentContact);
		LMessenger.first = false;
		base.LoadHome ();
	}
}
