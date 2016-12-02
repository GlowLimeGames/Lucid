﻿/* 
 * Author(s): Kevin Wang, Isaiah Mann
 * Description: Stores some meta-data about the individual message screens
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class LConversation : LData {
	public string ID;
	public float barLocation;
	public LContact[] participants {get; private set;}
	public List<LText> messages {get; private set;}
	public int messageCount {
		get {
			return messages.Count;
		}
	}
	public bool HasBegun {
		get {
			return messageCount > 0;
		}
	}
	bool isComplete = false;

	public LConversation (string id, params LContact[] participants) {
		this.ID = id;
		this.participants = participants;
		this.messages = new List<LText>();
	}

	public void AddMessage(LText message){
		messages.Add(message);
	}
		
	public void MarkAsComplete () {
		isComplete = true;
	}

	public bool CheckIsComplete () {
		return isComplete;
	}
}
