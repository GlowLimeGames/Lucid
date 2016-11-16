using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetVerticalPosition : MonoBehaviour {
	
	bool textAdded = false;
	bool textAddedB = false;
	bool pinged = false;
	GameObject lastAddedText;
	float windowSize = 900;
	float panelOffset = 300;
	ScrollRect rect;

	void Start(){
		rect = GetComponentInParent<ScrollRect> ();
	}

	void Update () {

		if (textAddedB||pinged){
			shift ();
			textAdded = false;
			textAddedB = false;
			pinged = false;
		}
		if (textAdded)
			textAddedB = true;

	}

	public void addText(GameObject text){
		textAdded = true;
		lastAddedText = text;
	}

	public void setWindowSize(float newSize){
		windowSize = newSize;
		pinged = true;
	}

	public void setOffset(float newSize){
		panelOffset = newSize;
		pinged = true;
	}

	void shift(){
		rect.velocity = Vector2.zero;

		Transform current = GetComponent<Transform> ();
		Transform textTransform = lastAddedText.GetComponent<Transform> ();

		float textH = lastAddedText.GetComponent<RectTransform> ().rect.height/2;
		float currentPos = current.localPosition.y;
		float textPos = textTransform.localPosition.y;

		//Debug.Log ("init textpos: "+textPos);
		//Debug.Log ("init currentpos: "+currentPos);
		//Debug.Log ("projected loc: " + (-textPos + textH * 2 - windowSize));


		float newPos = -textPos + textH * 2 - windowSize + panelOffset > 0 ? -textPos + textH * 2 - windowSize + panelOffset : 0;
		float newSize = -textPos + textH*2 + panelOffset;

		GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, newSize);
		Vector3 shiftPos = new Vector3(current.localPosition.x, newPos, current.localPosition.z);
		current.localPosition = shiftPos;

		//Debug.Log ("after currentpos: "+current.localPosition.y);
	}
}
