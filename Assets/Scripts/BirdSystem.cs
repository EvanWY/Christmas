using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSystem : MonoBehaviour {

	[Tooltip("bird prefab")]
	public GameObject bird_prefab;
	[Tooltip("Z bird prefab")]
	public GameObject ZBird_prefab;


	GameObject playerCharacter;

	[Tooltip("X offset to make sure bird is generated offScreen")]
    public float startXOffset;

    public Transform startingPoint;




	[Tooltip("")]
	public Vector2 doubleBirdIntervalRange;

	[Tooltip("Minimum X distance between birds")]
	public const float minimumXBetweenBirds = 1.3f;
	[Tooltip("Minimum Y distance between birds")]
	public const float minimumYBetweenBirds = 1.5f;


	float startTime;

	bool doubleBirdReady;
	float doubleBirdTimer;
	float doubleBirdTimer_max = float.MaxValue;
	//bool doubleBirdMaxAssigned;

	float lastCreatedYPos;


	// Use this for initialization
	void Start () {
		playerCharacter = GameObject.FindGameObjectWithTag ("Player");
		startTime = Time.time;
		StartCoroutine(GenBird());
	}

	/*
	/// <summary>
	/// double bird timer.
	/// </summary>
	/// <returns>The double bird.</returns>
	IEnumerator HandleDoubleBird(){
		while(true)
		{
			if (!doubleBirdReady) 
			{
				if (doubleBirdTimer < doubleBirdTimer_max) 
				{
					doubleBirdTimer += Time.deltaTime;
				} 
				else 
				{
					doubleBirdTimer = 0;
					doubleBirdReady = true;
					doubleBirdMaxAssigned = false;
				}
			}
			yield return null;
		}

	}
	*/

	// Update is called once per frame
	IEnumerator GenBird () {
        yield return new WaitForSeconds(4f);
		//for testing
		for(;;)
		{
			if(Input.GetKeyDown(KeyCode.Alpha1)){
				CreateOneBird ();
			}
			if(Input.GetKeyDown(KeyCode.M)){
				CreateTwoBird ();
			}

			yield return null;

		}

	}



	[Header("Single Bird Creation Info")]

	[Tooltip("X offset of the bird")]
	public Vector2 birdXOffset;
	[Tooltip("Y offset of the bird")]
	public Vector2 birdYOffset;

	/// <summary>
	/// Creates one bird.
	/// </summary>
	/// <returns>the bird gameobject created</returns>
	GameObject CreateOneBird(){
		Debug.Log ("create one bird");
		Random.InitState ((int)Time.time);
		Vector3 playerPos = playerCharacter.transform.position;

		float yOffset = UnityEngine.Random.Range (birdYOffset.x, birdYOffset.y);
		float xOffset = startXOffset + UnityEngine.Random.Range (birdXOffset.x, birdXOffset.y);

		Vector3 birdPos = playerPos + new Vector3 (xOffset, yOffset, 0);
		Debug.Log ("playerPos: " + playerPos);
		Debug.Log ("birdPos: " + birdPos);
		birdPos = CheckInScreen (birdPos);

		GameObject bird = Instantiate (bird_prefab, birdPos, Quaternion.identity) as GameObject;
		bird.GetComponent<Bird> ().Initialize (startTime);

		return bird;
	}

	[Header("Double Bird Creation Info")]
	[Tooltip("X offset for the 2nd bird. Range should be 0 ~ x(positive)")]
	public Vector2 doubleBirdXOffset;
	[Tooltip("Y offset for the 2nd bird. Range should be 0 ~ x(positive)")]
	public Vector2 doubleBirdYOffset;


	/// <summary>
	/// Creates two birds.
	/// </summary>
	/// <returns>an array of bird gameobjects created</returns>
	GameObject[] CreateTwoBird(){
		Debug.Log ("create two birds");
		Random.InitState ((int)Time.time);
		GameObject lastCreatedBird = CreateOneBird ();
		Vector3 lastCreatedPos = lastCreatedBird.transform.position;

		bool isAbove = HalfRandomSelector ();
		bool isRight = HalfRandomSelector ();
		float X_factor = isRight ? 1 : -1;
		float Y_factor = isAbove ? 1 : -1;

		float xPos = lastCreatedPos.x + X_factor * UnityEngine.Random.Range (doubleBirdXOffset.x, doubleBirdXOffset.y);
		float yPos = lastCreatedPos.y + Y_factor * UnityEngine.Random.Range (doubleBirdYOffset.x, doubleBirdYOffset.y);

		//check whether created Y position is on the screen; if not, change direction.
		if(yPos < screenYLimit.x || yPos > screenYLimit.y){
			isAbove = !isAbove;
			Y_factor = isAbove ? 1 : -1;
			yPos = lastCreatedPos.y + Y_factor * UnityEngine.Random.Range (doubleBirdYOffset.x, doubleBirdYOffset.y);
		}

		Vector3 birdPos = new Vector3 (xPos, yPos, lastCreatedPos.z);
		birdPos = CheckInScreen (birdPos);

		var bird = Instantiate (bird_prefab, birdPos, Quaternion.identity);
		bird.GetComponent<Bird> ().Initialize (startTime);

		GameObject[] result = new GameObject[2];
		result [0] = lastCreatedBird;
		result [1] = bird;
		return result;
	}

	void CreateThreeBird(){

	}

	void CreateBirdWave(){

	}

	void CreateOneZBird(){

	}

	void CreateTwoZBird(){

	}

	void CreateThreeZBird(){

	}

	[Tooltip("Contains the top and bottom limits of the screen on Y axis")] 
	public Vector2 screenYLimit;

	/// <summary>
	/// Checks whether the position passed in is in screen.
	/// </summary>
	/// <returns>The checked position on the screen.</returns>
	/// <param name="pos">position to be checked</param>
	Vector3 CheckInScreen(Vector3 pos){
		
		if (pos.y < screenYLimit.x)
			pos = new Vector3 (
				pos.x,
				screenYLimit.x,
				pos.z
			);

		if (pos.y > screenYLimit.y)
			pos = new Vector3 (
				pos.x,
				screenYLimit.y,
				pos.z
			);

		return pos;
	}


	bool HalfRandomSelector(){
		Random.InitState ((int)Time.time);
		bool result = UnityEngine.Random.Range (0f, 1f) > 0.5f ? true : false;
		return result;
	}
}
