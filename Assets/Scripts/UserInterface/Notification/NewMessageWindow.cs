/*
 * Author(s): Kevin Wang
 * Description: Class that controls behavior of a specific type of popup window:
 * 				a messenger notification
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class NewMessageWindow : PopupWindow {
	
	public GameObject messageWindow;

	public NewMessageWindow(string mess) : base (mess) {
	}

	public NewMessageWindow(string mess, Image icon) : base(mess, icon) {
	}
	/*
	public void setBut1(UnityAction one){
		button1.onClick.RemoveAllListeners ();
		button1.onClick.AddListener (one);
	}

	public void setBut2(UnityAction two){
		button2.onClick.RemoveAllListeners ();
		button2.onClick.AddListener (two);
	}


	public void CreatePanel(){
		
	}

	public void ClosePanel(){
		gameObject.SetActive(false);
		Destroy (this);
	}
	*/
}

