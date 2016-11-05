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

	LUILabledButton[] responseButtons;
	LText[] currentResponses;
	public bool HasResponses {
		get {
			return currentResponses != null;
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		toggle = GetComponentInChildren<ToggleController>();
		controller = GetComponentInParent<LMessengerScreenController>();
		responseButtons = GetComponentsInChildren<LUILabledButton>();
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
						controller.SendText(responses[index]);
					});
			} else {
				responseButtons[i].Hide();
			}
		}
	}
		
}
