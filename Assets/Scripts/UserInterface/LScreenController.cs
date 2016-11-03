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
	LUIController controller;

	protected override void FetchReferences () {
		base.FetchReferences ();
		controller = LUIController.Instance;
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
}
