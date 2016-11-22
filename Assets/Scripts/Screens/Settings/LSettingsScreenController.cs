/*
 * Author(s): Isaiah Mann
 * Description: Controls the settings screen
 */

using UnityEngine;

public class LSettingsScreenController : LScreenController {
	[SerializeField]
	LToggleableUIButton musicToggle;
	[SerializeField]
	LToggleableUIButton sfxToggle;

	const string ON = "On";
	const string OFF = "Off";
	const string SFX = "SFX";
	const string MUSIC = "Music";
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
		refreshButtonText();
		musicToggle.SubscribeToClick(refreshButtonText);
		musicToggle.SubscribeToggleOffAction(refreshButtonText);
		sfxToggle.SubscribeToClick(refreshButtonText);
		sfxToggle.SubscribeToggleOffAction(refreshButtonText);
	}

	void refreshButtonText () {
		musicToggle.SetText(formatButtonText(MUSIC, musicMuted ? OFF : ON));
		sfxToggle.SetText(formatButtonText(SFX, sfxMuted ? OFF : ON));
	}

	string formatButtonText (string type, string state) {
		return string.Format(FORMAT, type, state);
	}
}
