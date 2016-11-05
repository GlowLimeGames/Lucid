/*
 * Author: Isaiah Mann
 * Description: Represents a text in the mobile game Lucid
 */

[System.Serializable]
public class LText : LData {
	public string ID;
	public int IDNum {
		get {
			int idNum;
			if (tryParseFirstInt(ID, out idNum)) {
				return idNum;
			} else {
				return DEFAULT_INT_VALUE;
			}
		}
	}
	public string choice;
	public string Sender;
	public string Receiever;
	public string Body;
	public string[] Responses;
	public bool FromPlayer;
}
