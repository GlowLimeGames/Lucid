/*
 * Author(s): Isaiah Mann
 * Description: A generic tree node
 */

using System.Collections.Generic;

public class LTreeNode<LType> : LData {
	public LType Value;
	public List<LTreeNode<LType>> Children = new List<LTreeNode<LType>>();

	public LTreeNode (LType value) {
		this.Value = value;
	}


	public void AddChild(LType child) {
		AddChild(new LTreeNode<LType>(child));
	}

	public void AddChild(LTreeNode<LType> child) {
		Children.Add(child);
	}
}
