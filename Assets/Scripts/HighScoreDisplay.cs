using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour {
	
	void Start () {
		int highscore = SaveLoad.GetHighestScore();

		if (highscore <= 0) {
			transform.Find("oldmanhigh").gameObject.SetActive(false);
			transform.Find("oldmanlow").gameObject.SetActive(true);
			transform.Find("TextHighScore").gameObject.SetActive(false);
		}
		else {
			transform.Find("oldmanhigh").gameObject.SetActive(true);
			transform.Find("oldmanlow").gameObject.SetActive(false);
			transform.Find("TextHighScore").gameObject.SetActive(true);
			transform.Find("TextHighScore").GetComponent<Text>().text = "HIGHSCORE   " + highscore;
		}
	}
}
