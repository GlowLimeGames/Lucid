using UnityEngine;
using System.Collections;

public class LUIElement : MannBehaviour {
	protected override void SetReferences () {
		// Nothing
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

	public virtual void Show () {
		Toggle(true);
	}

	public virtual void Hide () {
		Toggle(false);
	}

	protected virtual void Toggle (bool isActive) {
		gameObject.SetActive(isActive);
	}
}
