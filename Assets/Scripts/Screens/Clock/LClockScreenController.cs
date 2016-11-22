/*
 * Author(s): Isaiah Mann
 * Description: Controls the clock screen
 */

using UnityEngine;
using UnityEngine.UI;

public class LClockScreenController : LScreenController {
	LUIToggleGroup timeToggle;
	[SerializeField]
	Text dayText;
	[SerializeField]
	LUIButton prevDayButton;
	[SerializeField]
	LUIButton nextDayButton;
	[SerializeField]
	int minImplementedDay;
	[SerializeField]
	int maxImplementedDay;

	static int[] hours = new int[]{9, 1, 6};
	static int currentDay = 1;
	LDayPhase currentDayPhase;
	protected override void SetReferences () {
		base.SetReferences ();
		timeToggle = GetComponentInChildren<LUIToggleGroup>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		story = LStoryController.Instance;
		refresh();
	}

	public void SetDayPhase (int phaseIndex) {
		SetDayPhase((LDayPhase) phaseIndex);
	}

	public void SetDayPhase (LDayPhase phase) {
		story.SetDay(currentDay, phase, hours[(int)phase]);
		refresh();
	}
			
	public void SetDay (int day) {
		story.SetDay(day, currentDayPhase, hours[(int)currentDayPhase]);
		refresh();
	}

	public void NextDay () {
		if (hasNextDay()) {
			changeDay(1);
		}
	}

	public void PreviousDay () {
		if (hasPrevDay()) {
			changeDay(-1);
		}
	}

	void updateButtons () {
		nextDayButton.ToggleInteractable(hasNextDay());
		prevDayButton.ToggleInteractable(hasPrevDay());
	}

	bool hasPrevDay () {
		return currentDay - 1 >= minImplementedDay;
	}

	bool hasNextDay () {
		return currentDay + 1 <= maxImplementedDay;
	}

	void changeDay (int deltaDays) {
		currentDay += deltaDays;
		SetDay(currentDay);
	}

	void refreshData () {
		currentDay = story.CurrentTime.Day;
		currentDayPhase = story.CurrentTime.Phase;
	}

	void updateUI () {
		updateTimeSelect();
		updateVisibleDay();
		updateButtons();
	}

	void refresh () {
		refreshData();
		updateUI();
	}

	void updateTimeSelect () {
		timeToggle.SelectButton((int) story.CurrentTime.Phase);
	}

	void updateVisibleDay () {
		dayText.text = currentDay.ToString();
	}
}
