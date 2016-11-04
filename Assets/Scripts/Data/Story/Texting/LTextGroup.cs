/*
 * Author: Isaiah Mann
 * Description: Represents a group of texts in the mobile game Lucid
 */

using System.Linq;
using System.Collections.Generic;

[System.Serializable]
public class LTextGroup : LDataGroup<LText> {
	public LTime Time {get; private set;}
	public LConversationTree Conversation {get; private set;}
	public void ParseTime () {
		Time = new LTime(GroupID);
	}

	public void CreateConversationTree () {
		List<LText> remainingTexts = new List<LText>(this.Elements);
		LConversationTree tree = new LConversationTree(remainingTexts.First());
		while (remainingTexts.Count > 0) { 
			
		}
	}
}
