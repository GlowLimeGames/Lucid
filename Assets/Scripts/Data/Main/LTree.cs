/*
 * Author: Isaiah Mann
 * Description: A generic tree class type
 */

public class LTree<LType> : LData {
	public LTreeNode<LType> Root;

	public LTree (LType rootVal) {
		this.Root = new LTreeNode<LType>(rootVal);
	}
}
