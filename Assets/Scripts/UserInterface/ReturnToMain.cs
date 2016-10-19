using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnToMain : MonoBehaviour {

	private string mainScreen;

	void Start(){
		mainScreen = "Home Screen";
	}

	public void toMain(){
		SceneManager.LoadSceneAsync (mainScreen);
		Scene newScene = SceneManager.GetSceneByName (mainScreen);
		SceneManager.SetActiveScene (newScene);
	}
}
