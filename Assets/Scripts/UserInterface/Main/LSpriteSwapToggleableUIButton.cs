/*
 * Author(s): Kevin Wang
 * Description: An extension of LUIButton that swaps two sprites (kinda poorly named)
 */

using UnityEngine;
using UnityEngine.UI;

public class LSpriteSwapToggleableUIButton : LUIButton {

	[SerializeField]
	Sprite toggledSprite;
	[SerializeField]
	Sprite untoggledSprite;

	public bool ShowToggle;
	protected bool toggled = false;
	MannAction toggleOffAction;
	protected Image buttonImage;

	public bool IsToggled {
		get {
			return toggled;
		}
	}

	public void SubscribeToggleOffAction (MannAction toggleAction) {
		toggleOffAction += toggleAction;
	}

	public void UnsubscribeToggleOffAction (MannAction toggleAction) {
		toggleOffAction -= toggleAction;
	}

	protected virtual void setToggle (bool isToggled) {
		toggled = isToggled;
	}

	public void Toggle () {
		toggled = !toggled;
		if (ShowToggle) {
			if (toggled) {
				buttonImage.sprite = toggledSprite;
			} else {
				buttonImage.sprite = untoggledSprite;
			}
		}
	}

	protected override void executeClick () {
		Toggle();
		if (toggled) {
			base.executeClick ();
		} else {
			executeToggleOff();
		}
	}

	protected virtual void executeToggleOff () {
		if (toggleOffAction != null) {
			toggleOffAction();
		}
	}

	protected override void SetReferences () {
		base.SetReferences ();
		buttonImage = GetComponent<Image>();
	}

}
