/*
 * Author: Isaiah Mann
 * Description: Represents a group of texts in the mobile game Lucid
 */

[System.Serializable]
public class LTextGroup : LDataGroup<LText> {
	public LTime Time {get; private set;}

	public void ParseTime () {
		Time = new LTime(GroupID);
	}
}
