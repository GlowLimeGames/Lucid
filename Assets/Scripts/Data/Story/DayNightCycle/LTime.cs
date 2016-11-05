/*
 * Author(s): Isaiah Mann
 * Description
 */

using System.Linq;

[System.Serializable]
public class LTime : LData {
	public const string DAY = "Day";
	protected const string MORNING = "morning";
	protected const string AFTERNOON = "afternoon";
	protected const string EVENING = "evening";
	protected const int DEFAULT_DAY = 1;

	public int Day;
	public LDayPhase Phase;

	public static LTime Default {
		get {
			return new LTime(DEFAULT_DAY);
		}
	}

	public LTime (int day, LDayPhase phase = default(LDayPhase)) {
		this.Day = day;
		this.Phase = phase;
	}

	public LTime (string interactionName) {
		this.Day = determineDay(interactionName);
		this.Phase = determineDayPhase(interactionName);
	}

	protected LDayPhase determineDayPhase(string interactionName) {
		if (interactionName.Contains(MORNING)) {
			return LDayPhase.Morning;
		} else if (interactionName.ToLower().Contains(AFTERNOON)) {
			return LDayPhase.Afternoon;
		} else if (interactionName.ToLower().Contains(EVENING)) {
			return LDayPhase.Evening;
		} else { 
			return default(LDayPhase);
		}
	}
		
	// Fails if there is a different number before the day in the string
	protected int determineDay(string interactionName) {
		int day;
		if (tryParseFirstInt(interactionName, out day)) {
			return day;
		} else {
			return DEFAULT_DAY;
		}
	}
}
