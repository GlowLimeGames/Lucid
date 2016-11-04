using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeDetection : MonoBehaviour {

	public float requiredMovement;
	public bool isHoriz;

	private bool validTouch;
	private RectTransform rect;

	void Start(){
		SwipeCheck ();
		validTouch = false;
		rect = GetComponent<RectTransform> ();
	}

	IEnumerator SwipeCheck(){
		Vector2 startPos = new Vector2 (0.0f, 0.0f);		
		while (gameObject.activeInHierarchy) {
			if (Input.touchCount==1){
				Touch touch = Input.GetTouch (0);
				Debug.Log ("One touch");
				if (touch.phase == TouchPhase.Began) {
					startPos = touch.position;
					if (RectTransformUtility.RectangleContainsScreenPoint (rect, startPos))
						validTouch = true;
				}
				if (touch.phase == TouchPhase.Moved && validTouch) {
					Vector2 movement = touch.deltaPosition;
					doThing (movement);
				}
				if (touch.phase==TouchPhase.Ended && validTouch){
					Vector2 deltaPos = touch.position - startPos;
					if (isHoriz && deltaPos.x >= requiredMovement)
						doOtherThing ();
					if (!isHoriz && deltaPos.y >= requiredMovement)
						doOtherThing ();
						validTouch = false;
				}
			}
		}
		yield return null;
	}

	private void doThing(Vector2 movement){
		
	}

	private void doOtherThing(){
		
	}
}
