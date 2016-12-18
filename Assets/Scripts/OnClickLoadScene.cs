using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClickLoadScene : MonoBehaviour {

	public string sceneName;

	void Awake() {
		GetComponent<Button>().onClick.AddListener(() => {
			SceneManager.LoadScene(sceneName);
		});
	}
}
