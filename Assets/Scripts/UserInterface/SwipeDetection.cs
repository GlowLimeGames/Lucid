using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwipeDetection : MonoBehaviour {

	public float requiredMovement;
	public bool isHoriz;

	private bool validTouch;
	private float top;
	private float bot;
	private float lef;
	private float rig;

	void Start(){
		SwipeCheck ();
		validTouch = false;
		Vector3[] corners = GetComponent<RectTransform> ().GetWorldCorners (); //we know this will make a nice rectangle with 0 rotation
		for(int i=0;i<4;i++){
			Vector3 corner = corners[i];
			Debug.Log ("x:" + corner.x);
			Debug.Log ("y:" + corner.y);
			if (i == 0) {
				top = corner.y;
				bot = corner.y;
				lef = corner.x;
				rig = corner.x;
			} else {
				if (corner.y > top)
					top = corner.y;
				else if (corner.y < bot)
					bot = corner.y;
				if (corner.x > rig)
					rig = corner.x;
				else if (corner.x < lef)
					lef = corner.x;
			}
		}
	}

	IEnumerator SwipeCheck(){
		Vector2 startPos = new Vector2 (0.0f, 0.0f);		
		while (gameObject.activeInHierarchy) {
			if (Input.touchCount==1){
				Touch touch = Input.GetTouch (0);
				Debug.Log ("One touch");
				if (touch.phase == TouchPhase.Began) {
					startPos = touch.position;
					if(startPos.x >=lef && startPos.y <= rig && startPos.y >= bot && startPos.y <= top)
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
