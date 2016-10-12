using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.EventSystems;

public class ChangeNotificationNumber : MonoBehaviour {

	public Text bubbleText;

	protected int numberNotifications;

	//in principle, there could be a number of different methods
	//for changing the number of new notifications, based on whether
	//all the notifications were viewed (e.g. if all unread emails were
	//marked as read), but that can probably be built into other apps
	//instead of being here

	//right now there is a cap on the number of notifications displayed
	//at 99, beyond which it will just add a '+'; the size of the bubble
	//should also be able to change to accomodate the larger size, but
	//that would require a new sprite.

	public void change(int newNumber){
		numberNotifications = newNumber;
		if (numberNotifications > 99) {
			resize ();
			bubbleText.text = "99+";
		} else {		
			bubbleText.text = "" + numberNotifications;
		}
	}


	//code to resize bubble; currently creates second bubble
	//offset slightly to simulate a larger bubble. Could be
	//expanded by either including new sprites for expanded
	//bubble and the gap in between, or just creating a sprite
	//for the expanded bubble, since as it is it is capped at
	//3 characters. Also it could just be that this doesn't matter
	//and the PC never gets more than like, 5 notifications for
	//the other apps.

	private void resize(){
		float radius = GetComponent<Rect> ().height / 2;
		Transform current = GetComponent<Transform> ();
		Vector3 newPos = current.position;
		newPos.x+=radius;
		Quaternion newRot = current.rotation;
		int sibIndex = current.GetSiblingIndex ();

		Image newBubble = (Image) Instantiate (gameObject, newPos,newRot);
		newBubble.GetComponent<Text> ().text = "";
		newBubble.transform.SetSiblingIndex (sibIndex + 1);

		bubbleText.transform.Translate (new Vector3 (radius / 2, 0.0f, 0.0f));
	}
}
