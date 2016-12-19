using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {

    private float birdSpeed;
	// Use this for initialization
	void Start () {
        float minRange = (1 - 1 / (Mathf.Pow(3, (Time.time / 60)))) * 6 + 1;
        float maxRange = (1 - 1 / (Mathf.Pow(3, (Time.time / 60)))) * 10 + 2;
        birdSpeed = Random.Range(minRange, maxRange);
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.left * birdSpeed * Time.deltaTime);
	}
}
