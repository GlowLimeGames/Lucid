/*
 * Author(s): Isaiah Mann
 * Description: Handles tracking progress in the game's narrative
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LStoryController : SingletonController<LStoryController>, IStoryController {
	public LTime CurrentTime{get; private set;}
	LDataController data;
	List<LConversation> activeConversations = new List<LConversation>();
	[SerializeField]
	LContact player;
	protected override void SetReferences () {
		base.SetReferences ();
		Reset();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		data = LDataController.Instance;
	}
		
	public LContact Player {
		get {
			return player;
		}
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

	public void TrackConversation (LConversation conversation) {
		activeConversations.Add(conversation);
	}

	// Checks for whether all the conversations for the day have been complete
	public bool ReadyToAdvanceeDayPhase () {
		bool allConversationsComplete = true;
		foreach (LConversation convo in activeConversations) {
			allConversationsComplete &= convo.CheckIsComplete();
			if (!allConversationsComplete) {
				return false;
			}
		}
		return allConversationsComplete;
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
