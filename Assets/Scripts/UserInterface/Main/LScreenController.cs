/*
 * Author(s): Isaiah Mann
 * Description: Superclass for each screen in the game
 */

using UnityEngine;
using System.Collections;

public abstract class LScreenController : Controller, IScreenController {
	protected bool isDebugging = false;
	const string HOME_SCREEN = "Home Screen";
	const string MESSAGING_SCREEN = "Messaging Screen";
	protected LUIController controller;
	protected LStoryController story;
	protected LDataController data;

	protected override void FetchReferences () {
		base.FetchReferences ();
		controller = LUIController.Instance;
		story = LStoryController.Instance;
		data = LDataController.Instance;
	}

	public void LoadHome () {
		controller.LoadScene(HOME_SCREEN);
	}

	public void LoadMessaging () {
		controller.LoadScene(MESSAGING_SCREEN);
	}

	public void LoadApp (string appName) {
		controller.LoadScene(appName);
	}

	public void ToggleMusic () {
		SettingsUtil.ToggleMusicMuted(!SettingsUtil.MusicMuted);
	}

	public void ToggleSFX () {
		SettingsUtil.ToggleSFXMuted();
	}
}
