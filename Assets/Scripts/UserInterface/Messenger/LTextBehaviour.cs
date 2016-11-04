/*
 * Author(s): Isaiah Mann
 * Description: Displays a visual text
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LTextBehaviour : LUIElement {
	Text body;
	[SerializeField]
	Image contactPic;
	bool hasImage = false;

	public void SetImage (Sprite sprite) {
		if (hasImage) {
			contactPic.sprite = sprite;
		}
	}

	public void SetText (string message) {
		body.text = message;
	}

	#region MannBehaviour Protocol

	protected override void SetReferences () {
		base.SetReferences ();
		body = GetComponentInChildren<Text>();
		if (contactPic) {
			hasImage = true;
		}
	}

	#endregion
}
