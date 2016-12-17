using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool isPaused;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
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
