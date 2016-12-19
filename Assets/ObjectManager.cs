using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This name sucks. It is responsible for generating birds.
/// </summary>

public class ObjectManager : MonoBehaviour {

	[SerializeField]
	Transform playerTransform;


	[SerializeField]
	float interval_min_bird;
	[SerializeField]
	float interval_max_bird;
	[SerializeField]
	float yPos_min_bird;
	[SerializeField]
	float yPos_max_bird;
	[SerializeField]
	float xOffset_bird;
	[SerializeField]
	GameObject bird_Prefab;
	[SerializeField]
	Transform gameMap;


	// Use this for initialization
	void Start () {
		StartCoroutine ("GeneratingBird");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator GeneratingBird(){
		while(true){
			float time = Random.Range (interval_min_bird, interval_max_bird);
			float yPos = Random.Range (yPos_min_bird, yPos_max_bird);

			yield return new WaitForSeconds (time);
			Vector3 position = new Vector3 (playerTransform.position.x + xOffset_bird, yPos, 0);
			GameObject birdCreated = Instantiate (bird_Prefab, position, Quaternion.identity, gameMap);
			//Debug.Log ("bird generated at " + position);

		}
	}


}
