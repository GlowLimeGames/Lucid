/*
 * Author(s): Kevin Wang, Isaiah Mann
 * Description: Controller for the messenger screen
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LMessengerScreenController : LScreenController {
	[SerializeField]
	GameObject npcTextPrefab;
	[SerializeField]
	GameObject playerTextPrefab;
	[SerializeField]
	Transform messageParent;

	[SerializeField]
	GameObject messageScrollView;

	List<LTextBehaviour> visualTexts = new List<LTextBehaviour>();

	// The data source that accesses all texting
	protected LMessageController messaging;
	protected LTextingResponder responder;

	protected override void SetReferences () {
		base.SetReferences ();
		responder = GetComponentInChildren<LTextingResponder>();
	}

	protected override void FetchReferences () {
		base.FetchReferences ();
		messaging = LMessageController.Instance;
	}

	public new void LoadHome(){
		//Debug.Log ("LoadHome");
		bool contacts = LMessengerAppController.isContactsOpen;

		Contact[] list = GetComponentsInChildren<Contact> (true);
		bool[] notes = new bool[list.Length];
		LConversation[] convs = new LConversation[list.Length];
		int i = 0;
		foreach (Contact c in list) {
			LContact lc = c.getContact();
			notes [i] = lc.BoolIsMessageUnread;
			convs [i] = c.conversation;
			i++;
		}
		LMessenger.set (contacts, notes, convs, GetComponentInChildren<LMessengerAppController> (true).currentContact);
		//LMessenger.first = false;
		base.LoadHome ();
	}

	// Can accept an arbitrary number or an array of LTexts and create them in order
	public void AddTexts (params LText[] texts) {
		foreach (LText text in texts) {
			AddText(text);	
		}
	}

	// Adds a visual text to the screen using an LText as the data source
	public LTextBehaviour AddText (LText text) {
		GameObject prefab = text.FromPlayer ? playerTextPrefab : npcTextPrefab;
		GameObject textObject = Instantiate(prefab, messageParent) as GameObject;
		Transform textTransform = textObject.transform;
		textTransform.localScale = Vector3.one;
		LTextBehaviour textBehaviour = textObject.GetComponent<LTextBehaviour>();
		textBehaviour.SetText(text.Body);
		visualTexts.Add(textBehaviour);
		return textBehaviour;
	}

	public void ClearAllTexts () {
		for (int i = 0; i < visualTexts.Count; i++) {
			Destroy(visualTexts[i].gameObject);
		}
		visualTexts.Clear();
	}

	public void SendText (LText text) {
		AddText(text);
	}

	public void DisplayResponses (LText text) {
		// TODO: Implement a tree like structure in LTextGroups
	}
}
