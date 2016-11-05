/*
 * Author(s): Isaiah Mann
 * Description: A graph that holds conversations
 */

using System.Collections.Generic;

public class LConversationGraph : LGraph<LText> {
	public LConversationGraph (params LGraphNode<LText>[] texts) {
		this.Nodes = texts;
	}

	public LGraphNode<LText> GetFirstMessage () {
		int lowestIdNum = int.MaxValue;
		int indexOfLowestId = -1;
		for (int i = 0; i < this.Nodes.Length; i++) {
			if (Nodes[i].Value.IDNum < lowestIdNum) {
				lowestIdNum = Nodes[i].Value.IDNum;
				indexOfLowestId = i;
			}
		}
		if (indexOfLowestId == -1) {
			return null;
		} else {
			return Nodes[indexOfLowestId];
		}

	}
}
