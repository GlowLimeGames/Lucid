using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonResponse : MonoBehaviour {

	protected string[] apps;

	void Start(){
	}

	public void buttonClick(int index){
		SceneManager.LoadSceneAsync ("App Template");//	apps [index]);
		Scene newScene = SceneManager.GetSceneByName ("App Template");
		SceneManager.SetActiveScene (newScene);//apps [index]);
	}
}
