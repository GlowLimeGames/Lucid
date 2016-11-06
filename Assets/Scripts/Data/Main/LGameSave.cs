/*
 * Author(s): Isaiah Mann
 * Description: A game save for Lucid
 */

[System.Serializable]
public class LGameSave : LData {
	public LTime Time;

	public LGameSave (LTime time) {
		this.Time = time;
	}
}
