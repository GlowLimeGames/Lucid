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
			LTextGroup newGroup;
			// Adds the group to the dictionary and sets a local ref to it on a single line
			allTexts.Add(text.name, newGroup = JsonUtility.FromJson<LTextGroup>(text.text));

			// Parse the time of the group now that we have a ref
			newGroup.ParseTime();
		}
		return allTexts;
	}
}
