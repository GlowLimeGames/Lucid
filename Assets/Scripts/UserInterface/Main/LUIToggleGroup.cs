/*
 * Author(s): Isaiah Mann
 * Description: Controls the toggle for multiple buttons
 */

public class LUIToggleGroup : LUIPanel {
	public bool SingleButtonSelect;
	LToggleableUIButton[] toggleButtons;

	protected override void SetReferences () {
		base.SetReferences ();
		toggleButtons = GetComponentsInChildren<LToggleableUIButton>();
		assignToggleSelect();
	}

	void assignToggleSelect () {
		for (int i = 0; i < toggleButtons.Length; i++) {
			int buttonIndex = i;
			toggleButtons[i].SubscribeToClick(
				delegate {
					SelectButton(buttonIndex);
				}
			);
		}
	}

	public void SelectButton (int buttonIndex) {
		if (SingleButtonSelect) {
			for (int i = 0; i < toggleButtons.Length; i++) {
				if (i != buttonIndex && toggleButtons[i].IsToggled) {
					toggleButtons[i].Toggle();
				}
			}
		}
		if (IntUtil.InRange(buttonIndex, toggleButtons.Length) && !toggleButtons[buttonIndex].IsToggled) {
			toggleButtons[buttonIndex].Toggle();
		}
	}

}
