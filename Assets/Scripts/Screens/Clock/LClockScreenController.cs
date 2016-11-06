/*
 * Author(s): Isaiah Mann
 * Description: Controls the clock screen
 */

public class LClockScreenController : LScreenController {
	LUIToggleGroup timeToggle;
	LStoryController story;

	protected override void SetReferences () {
		base.SetReferences ();
		timeToggle = GetComponentInChildren<LUIToggleGroup>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		story = LStoryController.Instance;
		updateTimeSelect(false);
	}

	public void SetDayPhase (int phaseIndex) {
		SetDayPhase((LDayPhase) phaseIndex);
	}

	public void SetDayPhase (LDayPhase phase) {
		story.SetDayPhase(phase);
		updateTimeSelect();
	}

	void updateTimeSelect (bool isButtonPress = true) {
		if (!isButtonPress) {
			timeToggle.SelectButton((int) story.CurrentTime.Phase);
		}
	}
}
