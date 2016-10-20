using UnityEngine;
using System.Collections;

public class LTutorialController : Controller, ITutorialController {

	public void PlayTutorial (string tutorialName) {
		Debug.Log("Playing tutorial " + tutorialName);
	}

	protected override void SetReferences () {
		// Nothing
	}

	protected override void FetchReferences () {
		// Nothing
	}

	protected override void HandleNamedEvent (string eventName) {
		// Nothing
	}

	protected override void CleanupReferences () {
		// Nothing
	}
}
