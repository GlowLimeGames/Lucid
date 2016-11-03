/* 
 * Created by: Kevin Wang
 * Description: Stores some meta-data about the messenger screen to be passed to the Home Screen
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class LMessenger {
	public static bool first = true;
	public static bool isContactsOpen;
	public static bool[] notifications;
	public static LConversation[] conversations;
	public static Contact currentOpen;

	public static void set(bool contacts, bool[] notes, LConversation[] convs){
		isContactsOpen = contacts;
		notifications = notes;
		conversations = convs;
		first = false;
	}

	public static void set(bool contacts, bool[] notes, LConversation[] convs, Contact current){
		isContactsOpen = contacts;
		notifications = notes;
		conversations = convs;
		currentOpen = current;
		first = false;
	}
}
