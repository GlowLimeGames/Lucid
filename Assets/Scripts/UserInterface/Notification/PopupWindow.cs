/*
 * Author(s): Kevin Wang
 * Description: A class that controls behavior of the popup windows
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class PopupWindow : MonoBehaviour {
	public Text message;
	public Image iconImage;
	public Button button1;
	public Button button2;
	public GameObject popup;

	public PopupWindow(string mess) {
		//GetComponentInChildren;
		message.text=mess;
	}

	public PopupWindow(string mess, Image icon) {
		message.text=mess;
		iconImage = icon;
	}

	public void setBut1(UnityAction one){
		button1.onClick.RemoveAllListeners ();
		button1.onClick.AddListener (one);
	}

	public void setBut2(UnityAction two){
		button2.onClick.RemoveAllListeners ();
		button2.onClick.AddListener (two);
	}


	public void CreatePanel(){
		//TODO: make the panel appear with the relevant properties
	}

	public void ClosePanel(){
		gameObject.SetActive (false);
		Destroy (this);
	}
}

