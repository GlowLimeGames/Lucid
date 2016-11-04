/*
 * Author(s): Isaiah Mann
 * Description: Represents a conversation (with a knowledge of the conversation flow
 */

public class LConversationTree : LTree<LText> {
	public LConversationNode CurrentNode;
	public LConversationTree(LText rootText) : base(rootText){}
}
