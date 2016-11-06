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
		checkTextRef();
		body.text = message;
	}

	void checkTextRef () {
		if (!body) {
			body = GetComponentInChildren<Text>();
		}
	}

	#region MannBehaviour Protocol

	protected override void SetReferences () {
		base.SetReferences ();
		checkTextRef();
		if (contactPic) {
			hasImage = true;
		}
	}
		
	#endregion
}
