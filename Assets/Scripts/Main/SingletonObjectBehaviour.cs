/*
 * Author(s): Isaiah Mann
 * Description: Describes the behaviour of a Singleton GameObject
 */

public class SingletonObjectBehaviour : MannBehaviour {
	public bool ShouldNotDestroyOnLoad;

	protected override void SetReferences () {
		if (ShouldNotDestroyOnLoad) {
			DontDestroyOnLoad(gameObject);
		}
	}

	protected override void FetchReferences () {
		// Nothing
	}

	protected override void HandleNamedEvent (string eventName) {
		// Nothing
	}

	protected override void CleanupReferences () {
		// Nothing
	}
}
