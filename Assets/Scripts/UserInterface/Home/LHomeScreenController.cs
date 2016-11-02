﻿/*
 * Author(s): Isaiah Mann, Kevin Wang
 * Description: Controls the home screen app
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LHomeScreenController : LScreenController {

	public GameObject popupWindow;
	public Text time;

	private string []apps = {"Home Screen", "App Template", "Messaging Screen"};

	public void LoadApp(int index){
		SceneManager.LoadScene(apps[index]);
	}

	//in principle creates a popup - not currently finished implementing
	public GameObject CreatePopup(){
		GameObject popup = Instantiate (popupWindow) as GameObject;
		PopupWindow popWindow = popup.GetComponent<PopupWindow>();
		popWindow.CreatePanel ();
		popup.SetActive (true);
		return popup;
	}

	//passes in string containing time, e.g. "4:56 AM"
	public void changeTime(string s){
		time.text = s;
	}

	//passes in int using military time, e.g. 1 PM = 1300
	public void changeTime(int intTime){
		string newTime = "";
		string AMorPM = "";
		if (intTime >= 2400||intTime<0)
			intTime %= 2400;
		if (intTime < 1200)
			AMorPM = " AM";
		else {
			AMorPM = " PM";
			intTime -= 1200;
		}
		if (intTime < 100)
			intTime += 1200;
		newTime = (intTime / 100) + ":";
		if (intTime % 100 == 0)
			newTime += "00" + AMorPM;
		else
			newTime += (intTime % 100) + AMorPM;
		time.text = newTime;
	}
}
