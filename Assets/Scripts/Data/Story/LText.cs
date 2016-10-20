/*
 * Author: Isaiah Mann
 * Description: Represents a text in the mobile game Lucid
 */

[System.Serializable]
public class LText {
	public string ID;
	public string Sender;
	public string Receiever;
	public string Body;
	public string[] Responses;
	public bool FromPlayer;
}
