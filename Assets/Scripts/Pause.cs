using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool isPaused;

	void Update () {

        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}
