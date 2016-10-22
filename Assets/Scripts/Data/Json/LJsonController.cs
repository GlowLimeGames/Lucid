/*
 * Author(s): Isaiah Mann
 * Description: Used to load JSON
 */

using UnityEngine;
using System.Collections;

public class LJsonController : SingletonController<LJsonController>, IJsonController {
	public T Parse<T> (string json) {
		return JsonUtility.FromJson<T>(json);
	}

	public LContactGroup LoadContacts (string jsonPath) {
		return Parse<LContactGroup>(getJsonText(jsonPath));
	}

	string getJsonText (string jsonPath) {
		return Resources.Load<TextAsset>(jsonPath).text;
	}
}
