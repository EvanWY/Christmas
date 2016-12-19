using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool isPaused;
    public PlayerMovement pm;
    public GameObject count3;
    public GameObject count2;
    public GameObject count1;
    public GameObject go;
    public Score score;

    public float GameTime;

    private float pausedTime;
    public GameObject pauseUI;
    private Background[] bg;

    void Start()
    {
        bg = GetComponentsInChildren<Background>();
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            pm.enabled = false;
            for (int i = 0; i < bg.Length; i++)
            {
                bg[i].enabled = false;
            }
            isPaused = true;
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

	bool isResuming = false;
	float startResumeRealTime;

    public void ResumeGame()
    {
        if (isPaused)
        {
            score.enabled = false;
            isPaused = false;
            pauseUI.SetActive(false);
			isResuming = true;
			startResumeRealTime = Time.unscaledTime;
		}
    }

	void Update() {
		if (isResuming && Time.unscaledTime - startResumeRealTime > 4f) {
			for (int i = 0; i < bg.Length; i++) {
				bg[i].enabled = true;
			}
			pm.enabled = true;
			score.enabled = true;
			Time.timeScale = 1f;
			isResuming = false;
		}
	}
}
