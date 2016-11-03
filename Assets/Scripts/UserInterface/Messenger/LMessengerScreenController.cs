/*
 * Author(s): Kevin Wang
 * Description: Controller for the messenger screen
 */

using UnityEngine;
using System.Collections;

public class LMessengerScreenController : LScreenController {

	public new void LoadHome(){
		if (isDebugging) {
			Debug.Log ("LoadHome");
		}
		bool contacts = LMessengerAppController.isContactsOpen;

		Contact[] list = GetComponentsInChildren<Contact> (true);
		bool[] notes = new bool[list.Length];
		LConversation[] convs = new LConversation[list.Length];
		int i = 0;
		foreach (Contact c in list) {
			LContact lc = c.getContact();
			notes [i] = lc.BoolIsMessageUnread;
			convs [i] = c.conversation;
			i++;
		}
		LMessenger.set (contacts, notes, convs, GetComponentInChildren<LMessengerAppController> (true).currentContact);
		LMessenger.first = false;
		base.LoadHome ();
	}
}
