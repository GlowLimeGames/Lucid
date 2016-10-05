using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonResponse : MonoBehaviour {

	//contains the destination scenes for each app
	//0-15 for the 16 apps arranged in rows at the top
	//16-19 for the 4 apps in the square
	//numbered from left to right, top to bottom
	protected string[] apps;

	//debug functionality changing the time with the buttons
	public Text time;

	public void buttonClick(int index){
		ChangeTime changes = gameObject.AddComponent<ChangeTime>();
		changes.time = time;
		changes.change (index * 100);
		//Debug.Log (index);
		//SceneManager.LoadScene (apps [index]);
	}
}
