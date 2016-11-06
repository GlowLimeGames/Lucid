/*
 * Created by: Kevin Wang
 * Description: Simple controller for making the buttons toggle between on and off
 */

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleController : LUIPanel {
	public Button button1;
	public Button button2;
	public Button button3;

	public Sprite Selected;
	public Sprite Deselected;

	private bool oneOn = false;
	private bool twoOn = false;
	private bool thrOn = false;

	private Image but1;
	private Image but2;
	private Image but3;

	protected override void SetReferences () {
		but1 = button1.GetComponent<Image>();
		but2 = button2.GetComponent<Image>();
		but3 = button3.GetComponent<Image>();
	}
		
	public void ToggleOff () {
		but1.sprite = Deselected;
		but2.sprite = Deselected;
		but3.sprite = Deselected;
		oneOn = false;
		twoOn = false;
		thrOn = false;
	}

	public void toggle(int index){
		switch (index) {
		case 1:
			if (oneOn) {
				but1.sprite = Deselected;
				oneOn = false;
			} else {
				but1.sprite = Selected;
				oneOn = true;
				but2.sprite = Deselected;
				but3.sprite = Deselected;
				twoOn = false;
				thrOn = false;
			}
			break;
		case 2:
			if (twoOn) {
				but2.sprite = Deselected;
				twoOn = false;
			} else {
				but2.sprite = Selected;
				twoOn = true;
				but1.sprite = Deselected;
				but3.sprite = Deselected;
				oneOn = false;
				thrOn = false;
			}
			break;
		case 3:
			if (thrOn) {
				but3.sprite = Deselected;
				thrOn = false;
			} else {
				but3.sprite = Selected;
				thrOn = true;
				but1.sprite = Deselected;
				but2.sprite = Deselected;
				twoOn = false;
				oneOn = false;
			}
			break;
		}
	}
}
