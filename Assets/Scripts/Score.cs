using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour {

    public int timeScore;
    public int totalScore;
    public int giftScore;
    public int giftNum;
    public Text scoreText;
	public Text giftNumText;

	private float gameTime;
    private bool manuallyPaused;

	// Use this for initialization
	float startTime;
	void Start () {
		startTime = Time.time;
		giftScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        gameTime = Time.time - startTime;
        timeScore = Mathf.RoundToInt(1.5f * Mathf.Pow(gameTime, 1.1f));
        totalScore = timeScore + giftScore;
        giftNum = ComboManager.currentComboNum;
        scoreText.text = totalScore.ToString();
		giftNumText.text = GiftManager.GiftSentNum.ToString();
		//Debug.Log(totalScore);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gift"))
        {
            giftScore += Mathf.RoundToInt(Mathf.Pow(30, 1 + (0.05f) * giftNum));
            //totalScore += giftScore;
        }
    }

	private void OnDisable() {
		//Debug.Log("OnDisable score store " + totalScore);
		SaveLoad.UpdateNewScore(totalScore);
	}
}
