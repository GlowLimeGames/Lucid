/*
 * Author(s): Isaiah Mann
 * Description: Controls the texting system. Loads data
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LMessageController : SingletonController<LMessageController>, IMessageController {
	const string TEXTING_PATH = "Texting";
	Dictionary<string, LTextGroup> allConversations;

	public bool TryGetConversation (string conversationName, out LTextGroup conversation) {
		return allConversations.TryGetValue(conversationName, out conversation);
	}

	protected override void SetReferences () {
		base.SetReferences ();
		allConversations = parseAllTexts();
	}

	Dictionary<string, LTextGroup> parseAllTexts () {
		TextAsset[] textAssets = Resources.LoadAll<TextAsset>(TEXTING_PATH);
		Dictionary<string, LTextGroup> allTexts = new Dictionary<string, LTextGroup>();
		foreach (TextAsset text in textAssets) {
			allTexts.Add(text.name, JsonUtility.FromJson<LTextGroup>(text.text));
		}
		return allTexts;
	}
}
