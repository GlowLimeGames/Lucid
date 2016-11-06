/*
 * Author(s): Isaiah Mann
 * Description: Controls the clock screen
 */

public class LClockScreenController : LScreenController {
	LUIToggleGroup timeToggle;
	static int[] hours = new int[]{9, 1, 6};
	static int day = 1;
	protected override void SetReferences () {
		base.SetReferences ();
		timeToggle = GetComponentInChildren<LUIToggleGroup>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		story = LStoryController.Instance;
		updateTimeSelect();
	}

	public void SetDayPhase (int phaseIndex) {
		SetDayPhase((LDayPhase) phaseIndex);
	}

	public void SetDayPhase (LDayPhase phase) {
		story.SetDay(day, phase, hours[(int)phase]);
	}
		
	void updateTimeSelect () {
		timeToggle.SelectButton((int) story.CurrentTime.Phase);
	}
}
