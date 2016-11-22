/*
 * Author(s): Isaiah Mann
 * Description: Handles tracking progress in the game's narrative
 */

using UnityEngine;
using System.Collections;

public class LStoryController : SingletonController<LStoryController>, IStoryController {
	public LTime CurrentTime{get; private set;}
	LDataController data;

	protected override void SetReferences () {
		base.SetReferences ();
		Reset();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		data = LDataController.Instance;
	}
		
	public void Set (LTime time) {
		this.CurrentTime = time;
	}

	public void SetDay (int day, LDayPhase dayPhase, int hour, int minute = 0) {
		CurrentTime = new LTime(day, hour, minute, dayPhase);
		sendDayPhaseTransitionEvent(dayPhase);
		data.Save();
	}

	public void Reset () {
		CurrentTime = LTime.Default;
	}

	void sendDayPhaseTransitionEvent (LDayPhase newPhase) {
		switch (newPhase) {
		case LDayPhase.Morning:
			EventController.Event(LEvent.TransitionToDay);
			break;
		case LDayPhase.Afternoon:
			EventController.Event(LEvent.TransitionToEvening);
			break;
		case LDayPhase.Evening:
			EventController.Event(LEvent.TransitionToNight);
			break;
		}
	}
}
