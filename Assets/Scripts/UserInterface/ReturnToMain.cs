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
		Debug.Log (SceneManager.GetActiveScene().name);
	}
}
