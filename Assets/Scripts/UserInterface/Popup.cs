using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Popup : MonoBehaviour {
	public Text messageText;
	public GameObject textComp;
	public Text btnText;
	public Button btn;
	// Use this for initialization
	void Start () {
		messageText = textComp.GetComponent<Text> ();
		//Debugging purposes
		btn.onClick.AddListener(dismiss);
		btnText =btn.GetComponentInChildren<Text> ();
		setText ("");
		setBtnText ("");

	}

	public void setText(string str){
		if (str == "") {
			messageText.text = "This is a test of the popup system";
		} else {
			messageText.text = "str";
		}
	}
	public void setBtnText(string str){
		if (str == "") {
			btnText.text = "dismiss";
		} else {
			btnText.text = "str";
		}
	}

	public void dismiss(){
		Destroy (this.gameObject);
	}
}
