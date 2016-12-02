/*
 * Author(s): Isaiah Mann, Kevin Wang
 * Description: Controls the settings screen
 */

using UnityEngine;

public class LSettingsScreenController : LScreenController {
	[SerializeField]
	LSpriteSwapToggleableUIButton musicToggle;
	[SerializeField]
	LSpriteSwapToggleableUIButton sfxToggle;

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
	}

	string formatButtonText (string type, string state) {
		return string.Format(FORMAT, type, state);
	}

}
