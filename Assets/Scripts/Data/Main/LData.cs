/*
 * Author(s): Isaiah Mann
 * Description: Abstract data class for Lucid data objects
 */

using System.Linq;

[System.Serializable]
public abstract class LData {
	protected const int DEFAULT_INT_VALUE = -1;

	// Adapated from: http://stackoverflow.com/questions/4734116/find-and-extract-a-number-from-a-string
	protected bool tryParseFirstInt (string inString, out int result) {
		return int.TryParse(new string(inString
			.SkipWhile(x => !char.IsDigit(x))
			.TakeWhile(x => char.IsDigit(x))
			.ToArray()), out result);
	}

}
