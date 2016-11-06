/*
 * Author(s): Isaiah Mann
 * Description: Handles tracking progress in the game's narrative
 */

using UnityEngine;
using System.Collections;

public class LStoryController : SingletonController<LStoryController>, IStoryController {
	public LTime CurrentTime = LTime.Default;
	LDataController data;

	protected override void FetchReferences () {
		base.FetchReferences ();
		data = LDataController.Instance;
	}

	public void SetDayPhase (LDayPhase dayPhase) {
		CurrentTime.Phase = dayPhase;
		data.Save();
	}

	public void Reset () {
		CurrentTime = LTime.Default;
	}
}
