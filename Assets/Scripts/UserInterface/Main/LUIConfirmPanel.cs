/*
 * Author(s): Isaiah Mann
 * Description: 
 */

using UnityEngine;
using UnityEngine.UI;

public class LUIConfirmPanel : LUIElement {
	[SerializeField]
	bool closeOnCancel;
	[SerializeField]
	bool clearEventsOnHide;
	[SerializeField]
	bool closeOnConfirm;
	[SerializeField]
	Text confirmText;
	string confirmTextFormat = "Are you sure {0}?";
	MannAction onCancel;
	MannAction onConfirm;

	protected override void SetReferences () {
		base.SetReferences ();
		checkToSubscribeDefaultEvents();
	}

	void checkToSubscribeDefaultEvents () {
		if (closeOnCancel) {
			onCancel += Hide;
		}
		if (closeOnConfirm) {
			onConfirm += Hide;
		}
	}

	public void SetConfirmTextFromFormat (string insert, bool formatted = true) {
		if (formatted) {
			confirmText.text = string.Format(confirmTextFormat, insert);
		} else {
			confirmText.text = insert;
		}
	}

	public void ClearButtonEvents () {
		onCancel = null;
		onConfirm = null;
		checkToSubscribeDefaultEvents();
	}

	public void SubscribeToCancel (MannAction action) {
		onCancel += action;
	}

	public void UnsubscribeFromCancel (MannAction action) {
		onCancel -= action;
	}


	public void SubscribeToConfirm (MannAction action) {
		onConfirm += action;
	}
		
	public void UnsubscribeFromConfirm (MannAction action) {	
		onCancel += action;
	}

	public void Cancel () {
		callOnCancel();
	}

	public void Confirm () {
		callOnConfirm();
	}

	public override void Hide () {
		base.Hide ();
		if (clearEventsOnHide) {
			ClearButtonEvents();
		}
	}

	void callOnCancel () {
		if (onCancel != null) {
			onCancel();
		}
	}

	void callOnConfirm () {
		if (onConfirm != null) {
			onConfirm();
		}
	}
}
