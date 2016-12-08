/*
 * Author(s): Isaiah Mann
 * Description: Controls notifications screen
 */

using UnityEngine;

public class LNotificationScreenController : LScreenController {
	[SerializeField]
	LUIConfirmPanel confirmAdvance;
	[SerializeField]
	LUIButton advanceButton;
	[SerializeField]
	LUIElement cannotAdvanceMessage;

	protected override void SetReferences () {
		base.SetReferences ();
		confirmAdvance.SubscribeToConfirm(advanceDayPhase);
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		toggleReadyToAdvance(story.ReadyToAdvanceDayPhase());
	}

	public void ShowConfirm () {
		confirmAdvance.Show();
	}

	void toggleReadyToAdvance (bool isReadyToAdvance) {
		if (isReadyToAdvance) {
			cannotAdvanceMessage.Hide();
			advanceButton.Show();
		} else {
			advanceButton.Hide();
			cannotAdvanceMessage.Show();
		}
	}
	void advanceDayPhase () {
		story.AdvanceDayPhase();
		// We know we'ren ot ready to advance again because we just changed day phases
		toggleReadyToAdvance(false);
	}
}
