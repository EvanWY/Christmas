using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour {

    private float birdSpeed;
	public float startTime;
	public AnimationCurve speedProb;
	// Use this for initialization
	void Start () {
        
		SetSpeed ();

    }

	void SetSpeed(){
		Random.InitState (gameObject.GetInstanceID());
		float minRange = (1 - 1 / (Mathf.Pow(3, (Time.time - startTime / 60)))) * 3 + 1;
		float maxRange = (1 - 1 / (Mathf.Pow(3, (Time.time - startTime / 60)))) * 10 + 2;

		float scaledRange = maxRange - minRange;

		float x = UnityEngine.Random.Range (0f, 1f);
		maxRange = minRange + scaledRange * speedProb.Evaluate (x);
		birdSpeed = Random.Range(minRange, maxRange);
		Debug.Log ("Bird speed: " + birdSpeed);
	}

	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.left * birdSpeed * Time.deltaTime);
	}
		
}
