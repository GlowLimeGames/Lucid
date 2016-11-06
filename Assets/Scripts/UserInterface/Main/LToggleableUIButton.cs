/*
 * Author(s): Isaiah Mann
 * Description: Describes a button behaviour which can be toggled and off
 */

using UnityEngine;
using UnityEngine.UI;

public class LToggleableUIButton : LUILabledButton {
	Color buttonUnselectedColor;
	Color buttonSelectedColor;

	public bool ShowToggle;
	bool toggled = false;
	MannAction toggleOffAction;
	Image buttonImage;
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
		
	public void Toggle () {
		toggled = !toggled;
		if (ShowToggle) {
			if (toggled) {
				buttonImage.color = buttonSelectedColor;
			} else {
				buttonImage.color = buttonUnselectedColor;
			}
		}
	}

	protected virtual void setToggle (bool isToggled) {
		toggled = isToggled;
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
		buttonUnselectedColor = buttonImage.color;
		buttonSelectedColor = Color.Lerp(buttonImage.color, Color.black, 0.5f);
	}
}
