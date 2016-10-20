/*
 * Author: Isaiah Mann
 * Description: Represents a group of texts in the mobile game Lucid
 */

[System.Serializable]
public class LTextGroup {
	public string GroupID;
	public LText[] Texts;
	public int Count {
		get {
			return Texts.Length;
		}
	}
	public LText this[int index] {
		get {
			if (index >= 0 && index < Count) {
				return Texts[index];
			} else {
				return null;
			}
		}
	}
}
