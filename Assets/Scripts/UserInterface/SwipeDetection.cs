using UnityEngine;
using System.Collections;

public class SwipeDetection : MonoBehaviour {

	public float requiredMovement;
	public bool isHoriz;

	void Start(){
		SwipeCheck ();
	}

	IEnumerator SwipeCheck(){
		Vector2 startPos = new Vector2 (0.0f, 0.0f);		
		while (gameObject.activeInHierarchy) {
			if (Input.touchCount==1){
				Touch touch = Input.GetTouch (0);
				Debug.Log ("One touch");
				if (touch.phase == TouchPhase.Began)
					startPos = touch.position;
				if (touch.phase == TouchPhase.Moved) {
					Vector2 movement = touch.deltaPosition;
					doThing ();
				}
				if (touch.phase==TouchPhase.Ended){
					Vector2 deltaPos = touch.position - startPos;
					if (deltaPos.magnitude >= requiredMovement)
						doOtherThing ();
				}
			}
		}
		yield return null;
	}

	private void doThing(){
		Debug.Log ("Filler 1");
	}

	private void doOtherThing(){
		Debug.Log ("Filler 2");
	}
}
