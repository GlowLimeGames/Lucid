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
	public LConversation[] Conversations {
		get {
			return activeConversations.ToArray();
		}
	}

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

	public void Set (LTime time, LConversation[] conversations) {
		this.CurrentTime = time;
		this.activeConversations = new List<LConversation>(conversations);
	}

	public void SetDay (int day, LDayPhase dayPhase, int hour, int minute = 0) {
		CurrentTime = new LTime(day, hour, minute, dayPhase);
		sendDayPhaseTransitionEvent(dayPhase);
		data.Save();
	}

	public void Reset () {
		CurrentTime = LTime.Default;
		activeConversations = new List<LConversation>();
	}

	public void TrackConversation (LConversation conversation) {
		activeConversations.Add(conversation);
		data.Save();
	}

	public bool IsTrackingConversation (LConversation conversation) {
		return activeConversations.Find(convo => convo.ID.Equals(conversation.ID)) != null;
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

	public bool TryLoadConversation (string conversationID, out LConversation convo) {
		convo = activeConversations.Find(conversation => conversation.ID.Equals(conversationID));
		return convo != null;
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
