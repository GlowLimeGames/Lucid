using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeNotificationBubble : MonoBehaviour {

	public Image notificationBubble;
	[Range(-30f,30f)]
	public float cornerOffset;

	protected bool hasBubble;
	protected Image currentBubble;

	public void Start(){
		hasBubble = false;
	}

	public void change(int newNum){
		if (hasBubble) {
			currentBubble.GetComponent<ChangeNotificationNumber>().change (newNum);
		} else {
			float offset = GetComponent<RectTransform> ().rect.height / 2;
			offset += cornerOffset;

			//Transform upperCorner = (Transform) Instantiate (GetComponent<Transform> ());
			//upperCorner.position = new Vector3(offset, offset, 0.0f);

			Image newBubble = Instantiate(notificationBubble);
			newBubble.transform.SetParent (gameObject.transform, false);
			RectTransform setAnchors = newBubble.GetComponent<RectTransform> ();
			setAnchors.anchorMin = new Vector2 (0.5f,0.5f);
			setAnchors.anchorMax = new Vector2 (0.5f,0.5f);

			newBubble.GetComponent<Transform> ().localPosition= new Vector3 (offset, offset, 0.0f);

			hasBubble = true;
			currentBubble = newBubble;
			currentBubble.GetComponent<ChangeNotificationNumber>().change (newNum);
		}
	}
}
