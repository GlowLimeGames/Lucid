/*
 * Author: Isaiah Mann
 * Description: Testing the JSON text parsing system
 */

using UnityEngine;

public class TextParsingTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LTextGroup textGroup = JsonUtility.FromJson<LTextGroup>(Resources.Load<TextAsset>("Texting/Example").text);
		Debug.Log(textGroup.Count);
		Debug.Log(textGroup[0].Body);
	}
}
