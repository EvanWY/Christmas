using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float birdLaunchRandomRange;
    public GameObject birdInstance;
    public GameObject playerCharacter;
    public float startingPointOffset;
    public float birdSpeed;

    public Transform startingPoint;
    private float rnd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        startingPoint.position = playerCharacter.transform.position + new Vector3(startingPointOffset, 0, 0);
        float rnd = Random.Range(0f, 1f);

        if(rnd < birdLaunchRandomRange)
        {
            var bird = Instantiate(birdInstance, startingPoint);
            bird.transform.Translate(Vector3.left * birdSpeed * Time.deltaTime);
        }
	}
}
