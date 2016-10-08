using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeNotificationBubble : MonoBehaviour {

	public Image notificationBubble;

	protected static bool hasBubble;

	public void start(){
		hasBubble = false;
	}


}
