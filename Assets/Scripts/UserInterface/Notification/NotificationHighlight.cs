using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NotificationHighlight : MonoBehaviour {

	private bool isOn;
	private Color originalColor;

	void Start(){
		isOn = false;
		Image currentIcon = GetComponent<Image> ();
		originalColor=currentIcon.color;
	}

	public void toggleHighlight(){
		if (!isOn)
			highlightIcon ();
		else
			revertIcon ();
	}

	private void highlightIcon(){
		isOn = true;
		//Debug.Log ("HIGHLIGHTED");
		Color iconColor = GetComponent<Image>().color;
		iconColor.r = makeWhite (iconColor.r);
		iconColor.g = makeWhite (iconColor.g);
		iconColor.b = makeWhite (iconColor.b);
		GetComponent<Image>().color=iconColor;
	}
		
	private void revertIcon(){
		isOn = false;
		GetComponent<Image>().color = originalColor;
	}

	private float makeWhite(float f){
		if (f > 1 || f < 0)
			return 0;
		float dif = 1 - f;
		return f + 0.3f * dif;
	}
}
