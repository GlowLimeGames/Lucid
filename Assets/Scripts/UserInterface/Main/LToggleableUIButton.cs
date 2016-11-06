/*
 * Author(s): Isaiah Mann
 * Description: Describes a button behaviour which can be toggled and off
 */

public class LToggleableUIButton : LUILabledButton {
	bool toggled = false;
	MannAction toggleOffAction;

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
}
