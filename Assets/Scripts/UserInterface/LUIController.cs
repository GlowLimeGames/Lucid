using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LUIController : SingletonController<LUIController>, IUIController {
	public GameObject popup;
	public void LoadScene (string sceneName) {
		SceneManager.LoadScene(sceneName);
	}
	public void spawnPopup(string bodyTxt, string btnTxt){
			Instantiate (popup);
			popup.setTxt(bodyTxt);
			popup.setBtnTxt(btnTxt);
	}
}
