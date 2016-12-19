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

    private float gameTime;
    private bool manuallyPaused;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        gameTime = Time.time;
        timeScore = Mathf.RoundToInt(10 * Mathf.Pow(gameTime, 1.2f));
        totalScore = timeScore + giftScore;
        giftNum = ComboManager.currentComboNum;
        scoreText.text = totalScore.ToString();
        Debug.Log(totalScore);
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gift"))
        {
            giftScore = Mathf.RoundToInt(Mathf.Pow(50, 1 + (0.05f) * giftNum));
            totalScore += giftScore;
        }
    }
}
