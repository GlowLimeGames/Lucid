/*
 * Author(s): Isaiah Mann, Kevin Wang
 * Description: Controls the settings screen
 */

using UnityEngine;
using UnityEngine.UI;

public class LSettingsScreenController : LScreenController {
	[SerializeField]
	LSpriteSwapToggleableUIButton musicToggle;
	[SerializeField]
	LSpriteSwapToggleableUIButton sfxToggle;
	[SerializeField]
	LUIButton resetButton;
	[SerializeField]
	LUIConfirmPanel confirmReset;
	[SerializeField]
	LUIElement mainPanel;
	[SerializeField]
	LUIElement creditsPanel;

	const string ON = "On";
	const string OFF = "Off";
	const string SFX = "SFX";
	const string MUSIC = "Music";
	const string RESET = "you want to reset all data";
	const string FORMAT = "{0} {1}";
	bool musicMuted {
		get {
			return SettingsUtil.MusicMuted;
		}
	}
	bool sfxMuted {
		get {
			return SettingsUtil.SFXMuted;
		}
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		if (musicMuted) {
			musicToggle.Toggle();
		}
		if (sfxMuted) {
			sfxToggle.Toggle();
		}
		resetButton.SubscribeToClick(openConfirmResetPanel);
		confirmReset.SubscribeToConfirm(resetGame);
		confirmReset.SetConfirmTextFromFormat(RESET);
	}

	void openConfirmResetPanel () {
		confirmReset.Show();
	}

	void resetGame () {
		data.Reset();
		data.Save();
	}

	string formatButtonText (string type, string state) {
		return string.Format(FORMAT, type, state);
	}

	public void openMainPanel(){
		mainPanel.Show ();
		creditsPanel.Hide ();
	}

	public void openCreditsPanel(){
		mainPanel.Hide ();
		creditsPanel.Show ();
	}
}
