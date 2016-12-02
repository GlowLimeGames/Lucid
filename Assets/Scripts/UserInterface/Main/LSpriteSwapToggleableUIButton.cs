/*
 * Author(s): Kevin Wang
 * Description: An extension of LUIButton that swaps two sprites (kinda poorly named)
 */

using UnityEngine;
using UnityEngine.UI;

public class LSpriteSwapToggleableUIButton : LToggleableUIButton {

	[SerializeField]
	Sprite toggledSprite;
	[SerializeField]
	Sprite untoggledSprite;

	public override void Toggle () {
		toggled = !toggled;
		if (ShowToggle) {
			if (toggled) {
				buttonImage.sprite = toggledSprite;
			} else {
				buttonImage.sprite = untoggledSprite;
			}
		}
	}
}
