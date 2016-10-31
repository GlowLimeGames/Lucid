/*
 * Authors: Isaiah Mann, David Tuttle
 * Description: 
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LUIController : SingletonController<LUIController>, IUIController {
	public GameObject popup;

	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}

	public void spawnPopup(string bodyTxt, string btnTxt){
		Popup popup = Instantiate (this.popup).GetComponent<Popup>();
		popup.setText(bodyTxt);
		popup.setBtnText(btnTxt);
	}
}
