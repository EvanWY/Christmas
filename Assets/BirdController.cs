using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {

	float speed;

	[SerializeField]
	float speed_min;
	[SerializeField]
	float speed_max;

	public bool isSeen;

	// Use this for initialization
	void Start () {
		speed = UnityEngine.Random.Range (speed_min, speed_max);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-speed*Time.deltaTime, 0, 0);
	}

	void OnBecameVisible(){
		isSeen = true;
	}

	void OnBecameInvisible(){
		
		Destroy (gameObject);
	}


}
