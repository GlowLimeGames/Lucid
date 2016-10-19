using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonResponse : MonoBehaviour {

	protected string[] apps; //contains the Scene names for each app

	//debug functionality iterating number in notification bubbles on click
	private int count;

	//debug functionality changing the time with the buttons
	public Text timePanel;

	void Start(){
		count = 1;
	}

	public void buttonClick(int index){

		//Debug.Log (index);
		if (index % 2 == 0) {
			SceneManager.LoadSceneAsync ("App Template");//	apps [index]);
			Scene newScene = SceneManager.GetSceneByName ("App Template");
			/*
			Debug.Log (newScene.IsValid());
			if(!(newScene.IsValid() || newScene.isLoaded)){
				SceneManager.LoadSceneAsync("App Template");//	apps [index]);
				newScene = SceneManager.GetSceneByName("App Template");
			}
			*/
			SceneManager.SetActiveScene (newScene);//apps [index]);
		} else {
			//various debug functions
			ChangeTime changes = timePanel.GetComponent<ChangeTime> ();
			changes.change (index * 100);

			ChangeNotificationBubble noteTest = gameObject.GetComponent<ChangeNotificationBubble> ();
			//noteTest.notificationBubble = image;
			noteTest.change (count);
			int adding = Random.Range (1, 5);
			count += adding;

			NotificationHighlight highlightTest = gameObject.GetComponent<NotificationHighlight> ();
			highlightTest.toggleHighlight ();
		}
	}
}
