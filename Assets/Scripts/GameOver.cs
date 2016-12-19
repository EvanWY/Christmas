using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public GameObject gameOverPanel;
    public Score scoreSystem;
    public ComboManager comboSystem;
    public PlayerMovement movementSystem;
    public Text totalScore;
    public Text highestGiftNumber;
	// Use this for initialization
	void Start () {

        scoreSystem.enabled = false;
        comboSystem.enabled = false;
        movementSystem.enabled = false;
        StartCoroutine(ShowGameOver());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(2.5f);
        gameOverPanel.SetActive(true);
        totalScore.text = scoreSystem.totalScore.ToString();
        highestGiftNumber.text = ComboManager.highestComboNum.ToString();
    }
}
