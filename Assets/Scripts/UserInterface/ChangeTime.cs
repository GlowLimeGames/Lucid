/*
 * Authors: Sam and Kevin
 * Description: Handles the clock and the display of time
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeTime : MonoBehaviour {

	//changes time shown on status bar

	//Text variable containing the time
	public Text time;

	public ChangeTime(Text t){
		time = t;
	}

	//passes in string containing time, e.g. "4:56 AM"
	public void change(string s){
		time.text = s;
	}

	//passes in int using military time, e.g. 1 PM = 1300
	public void change(int intTime){
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
