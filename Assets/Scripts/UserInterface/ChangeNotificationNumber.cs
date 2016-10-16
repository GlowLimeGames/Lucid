using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class ChangeNotificationNumber : MonoBehaviour {

	public Text bubbleText;

	protected int numberNotifications;

	public void change(int newNumber){ //sets number of notifications; if over 99 sets to '99+'
		numberNotifications = newNumber;
		if (numberNotifications > 99) {
			bubbleText.text = "99+";
		} else {		
			bubbleText.text = "" + numberNotifications;
		}
	}
}