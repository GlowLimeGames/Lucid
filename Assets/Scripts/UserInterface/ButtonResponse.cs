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
		count = 0;
	}

	public void buttonClick(int index){
		ChangeTime changes = timePanel.GetComponent<ChangeTime>();
		changes.change (index * 100);

		ChangeNotificationBubble noteTest = gameObject.GetComponent<ChangeNotificationBubble> ();
		//noteTest.notificationBubble = image;
		noteTest.change (count);
		count += 10;

		NotificationHighlight highlightTest = gameObject.GetComponent<NotificationHighlight> ();
		highlightTest.toggleHighlight ();

		//Debug.Log (index);
		SceneManager.LoadSceneAsync("App Template");//apps [index]);
		Scene newScene = SceneManager.GetSceneByName("App Template");
		Debug.Log(newScene.isLoaded);
		SceneManager.SetActiveScene (newScene);//apps [index]);
	}
}
