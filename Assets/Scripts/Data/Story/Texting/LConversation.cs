/* 
 * Author(s): Kevin Wang, Isaiah Mann
 * Description: Stores some meta-data about the individual message screens
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class LConversation : LData {
	public float barLocation;
	public LContact[] participants {get; private set;}
	public List<LText> messages {get; private set;}
	public int messageCount {
		get {
			return messages.Count;
		}
	}

	public LConversation (params LContact[] participants) {
		this.participants = participants;
		this.messages = new List<LText>();
	}

	public void AddMessage(LText message){
		messages.Add(message);
	}

	public bool CheckIsComplete () {
		throw new System.NotImplementedException();
	}
}
