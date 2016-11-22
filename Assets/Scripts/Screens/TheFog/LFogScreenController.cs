/*
 * Author(s): Isaiah Mann
 * Description: Controls the fog app
 */

public class LFogScreenController : LScreenController {
	protected override void FetchReferences () {
		base.FetchReferences ();
		EventController.Event(LEvent.FogButtonClick);
	}

}
