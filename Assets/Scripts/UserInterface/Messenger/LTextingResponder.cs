/*
 * Author(s): Isaiah Mann
 * Description: Controls the sending and displaying of texting responses
 */

using UnityEngine;
using System.Collections;

public class LTextingResponder : LUIPanel {
	protected ToggleController toggle;

	protected override void SetReferences () {
		base.SetReferences ();
		toggle = GetComponentInChildren<ToggleController>();
	}
}
