/*
 * Author(s): Isaiah Mann
 * Description: Controls notifications screen
 */

using UnityEngine;

public class LNotificationScreenController : LScreenController {
	[SerializeField]
	LUIConfirmPanel confirmAdvance;
	[SerializeField]
	LUILabledButton advanceButton;
	[SerializeField]
	LUILabledButton cannotAdvanceMessage;
	[SerializeField]
	string confirmPrefix = "Are you sure you want";
	[SerializeField]
	string unableToConfirmPrefix = "Finish all converations";
	[SerializeField]
	string[] confirmResponses = {
		"to go to school",
		"to go home",
		"to go to bed"};


	protected override void SetReferences () {
		base.SetReferences ();
		confirmAdvance.SubscribeToConfirm(advanceDayPhase);
		confirmAdvance.SubscribeToConfirm(LoadHome);
		confirmAdvance.SubscribeToCancel(LoadHome);
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		toggleReadyToAdvance(story.ReadyToAdvanceDayPhase());
	}

	public void ShowConfirm () {
		confirmAdvance.Show();
	}

	void toggleReadyToAdvance (bool isReadyToAdvance) {
		int dayPhaseIndex = (int) story.CurrentTime.Phase;
		string contextSpecificPhrase = confirmResponses[dayPhaseIndex];
		if (isReadyToAdvance) {
			cannotAdvanceMessage.Hide();
			advanceButton.Show();
			advanceButton.SetText(string.Format("{0} {1}?", confirmPrefix, contextSpecificPhrase)); 
			ShowConfirm();
		} else {
			advanceButton.Hide();
			cannotAdvanceMessage.Show();
			cannotAdvanceMessage.SetText(string.Format("{0} {1}.", unableToConfirmPrefix, contextSpecificPhrase)); 
		}
	}
	void advanceDayPhase () {
		story.AdvanceDayPhase();
		// We know we'ren ot ready to advance again because we just changed day phases
		toggleReadyToAdvance(false);
	}
}
