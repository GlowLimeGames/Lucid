/*
 * Author(s): Isaiah Mann
 * Description: Controls the sending and displaying of texting responses
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LTextingResponder : LUIPanel {
	protected LMessengerScreenController controller;
	protected ToggleController toggle;

	LText currentlySelectedText;
	LToggleableUIButton[] responseButtons;
	LToggleableUIButton mostRecentPressedResponseButton;

	LText[] currentResponses;
	public bool HasResponses {
		get {
			return currentResponses != null;
		}
	}

	public bool HasSelectedText {
		get {
			return currentlySelectedText != null;
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		toggle = GetComponentInChildren<ToggleController>();
		controller = GetComponentInParent<LMessengerScreenController>();
		responseButtons = GetComponentsInChildren<LToggleableUIButton>();
	}

	public void SetResponses (params LText[] responses) {
		this.Show();
		this.currentResponses = responses;
		for (int i = 0; i < responseButtons.Length; i++) {
			if (i < responses.Length) {
				int index = i;
				responseButtons[i].Show();
				responseButtons[i].Set(responses[i].Body, 
					delegate {
						SetSelectedText(responses[index]);
						mostRecentPressedResponseButton = responseButtons[index];
					});
				responseButtons[i].SubscribeToggleOffAction(ClearSelectedText);
			} else {
				responseButtons[i].Hide();
			}
		}
	}

	public void ToggleResponses (bool areVisible) {
		if (responseButtons == null) {
			return;
		}

		foreach (LToggleableUIButton response in responseButtons) {
			if (areVisible) {
				response.Show();
			} else {
				response.Hide();
			}
		}
	}

	public void SetSelectedText (LText text) {
		currentlySelectedText = text;
	}

	public void ClearSelectedText () {
		SetSelectedText(null);
	}

	public void SendText () {
		if (HasSelectedText) {
			controller.SendText(currentlySelectedText);
			ClearSelectedText();
			toggle.ToggleOff();
			mostRecentPressedResponseButton.Toggle();
		}
	}
}
