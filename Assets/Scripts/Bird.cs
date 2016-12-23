using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float birdLaunchRandomRange;
    public GameObject birdInstance;
    public GameObject playerCharacter;
    public float startingPointOffset;

    public Transform startingPoint;

	public Vector2 screenVertLimit;
	public Vector2 birdHorizontalOffset;
	public Vector2 birdVerticalOffset;
	public Vector2 doubleBirdVerticalOffset;
	public Vector2 doubleBirdIntervalRange;
	public float minimumYBetweenBirds;


	float startTime;

	bool doubleBirdReady;
	float doubleBirdTimer;
	float doubleBirdTimer_max = float.MaxValue;
	bool doubleBirdMaxAssigned;

	float lastCreatedYPos;



	// Use this for initialization
	void Start () {
		startTime = Time.time;
		StartCoroutine(GenBird());
	}

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

	// Update is called once per frame
	IEnumerator GenBird () {
        yield return new WaitForSeconds(4f);
		StartCoroutine ("HandleDoubleBird");
        for (;;)
        {
            float minRange = (1 / (Mathf.Pow(3, ((Time.time - startTime) / 60)))) * 6 + 1;
            float maxRange = (1 / (Mathf.Pow(3, ((Time.time - startTime) / 60)))) * 10 + 2;
			float rnd = Random.Range(minRange, maxRange);


			CreateBird (false);
			if(!doubleBirdMaxAssigned){
				doubleBirdTimer_max = rnd 
					+ UnityEngine.Random.Range (doubleBirdIntervalRange.x, doubleBirdIntervalRange.y);
				doubleBirdMaxAssigned = true;
			}

			if(doubleBirdReady){
				yield return new WaitForEndOfFrame();
				CreateBird (true);
				doubleBirdReady = false;
			}

			doubleBirdTimer_max = rnd;
            yield return new WaitForSeconds(rnd);
        }
	}

	void CreateBird(bool isDouble){
		Random.InitState ((int)Time.time);
		float yPos = UnityEngine.Random.Range (birdVerticalOffset.x, birdVerticalOffset.y);

		if (isDouble) {
			startingPoint.position = playerCharacter.transform.position + new Vector3(
				startingPointOffset + UnityEngine.Random.Range (birdHorizontalOffset.x, birdHorizontalOffset.y), 
				lastCreatedYPos + UnityEngine.Random.Range(doubleBirdVerticalOffset.x, doubleBirdVerticalOffset.y), 
				0);
			
			//check distance between birds created at the same time
			if (Mathf.Abs (startingPoint.position.y - lastCreatedYPos) < minimumYBetweenBirds) {
				float randomNum = UnityEngine.Random.Range (0f, 1f);
				if (randomNum < 0.5f) {
					startingPoint.position = new Vector3 (startingPoint.position.x,
						startingPoint.position.y + minimumYBetweenBirds,
						startingPoint.position.z);	
				} else {
					startingPoint.position = new Vector3 (startingPoint.position.x,
						startingPoint.position.y - minimumYBetweenBirds,
						startingPoint.position.z);
				}
			}
		} 
		else {
			startingPoint.position = playerCharacter.transform.position + new Vector3(
				startingPointOffset + UnityEngine.Random.Range (birdHorizontalOffset.x, birdHorizontalOffset.y) 
				, yPos, 0);
		}

		//check in screen
		if (startingPoint.position.y < screenVertLimit.x)
			startingPoint.position = new Vector3 (
				startingPoint.position.x,
				screenVertLimit.x,
				startingPoint.position.z
			);


		if (startingPoint.position.y > screenVertLimit.y)
			startingPoint.position = new Vector3 (
				startingPoint.position.x,
				screenVertLimit.y,
				startingPoint.position.z
			);

		var bird = Instantiate(birdInstance);
		bird.GetComponent<BirdFly> ().startTime = startTime;
		bird.transform.position = startingPoint.position;
		lastCreatedYPos = bird.transform.position.y;
		Destroy(bird, 6f);
	}
}
