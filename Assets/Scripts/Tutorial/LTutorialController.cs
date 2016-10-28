/*
 * Author(s): Isaiah Mann, Kevin Wang
 * Description: Controls the game's tutorials
 */


using UnityEngine;
using System.Collections;

public class LTutorialController : Controller, ITutorialController {

	public void PlayTutorial (string tutorialName) {
		// TODO: Actually implement this method

		Debug.Log("Playing tutorial " + tutorialName);
	}

	public void step(){
		//LHomeScreenController.createPopup();
	}
}
