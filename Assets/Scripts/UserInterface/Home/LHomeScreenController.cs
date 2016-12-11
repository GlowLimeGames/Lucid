/*
 * Author(s): Isaiah Mann, Kevin Wang
 * Description: Controls the home screen app
 */

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LHomeScreenController : LScreenController {
	static bool firstTimeBootup = true;
	[SerializeField]
	Sprite[] backgroundWallpapersVariant1;
	[SerializeField]
	Sprite[] backgroundWallpapersVariant2;
	Sprite[][] backgroundWallPapers;
	public GameObject popupWindow;
	public Text time;
	[SerializeField]
	Text day;
	[SerializeField]
	ChangeNotificationNumber pushNotifications;

	public Image background;

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
		this.time.text = s;
	}

	public void SetDay (string day) {
		this.day.text = day;
	}

	public void SetBackground(Sprite s){
		this.background.sprite = s;
	}
		
	void setBackgroundWallpaper () {
		int dayPhaseIndex = (int) story.CurrentTime.Phase;
		SetBackground(backgroundWallPapers[Random.Range(0, backgroundWallPapers.Length)][dayPhaseIndex]);
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

	protected override void SetReferences () {
		base.SetReferences ();
		backgroundWallPapers = new Sprite[][]{backgroundWallpapersVariant1, backgroundWallpapersVariant2};
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		LTime time = story.CurrentTime;
		SetDay(time.GetDayString());
		changeTime(time.GetTimeString());
		if (firstTimeBootup) {
			EventController.Event(LEvent.BootUp);
			firstTimeBootup = false;
		}
		setBackgroundWallpaper();
		setPushNotifications();
	}

	void setPushNotifications () {
		pushNotifications.ToggleActive(story.ReadyToAdvanceDayPhase());
	}
}
