using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float birdLaunchRandomRange;
    public GameObject birdInstance;
    public GameObject playerCharacter;
    public float startingPointOffset;

    public Transform startingPoint;

	float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;

		StartCoroutine(GenBird());
	}
	
	// Update is called once per frame
	IEnumerator GenBird () {
        yield return new WaitForSeconds(4f);
        for (;;)
        {
            float minRange = (1 / (Mathf.Pow(3, ((Time.time - startTime) / 60)))) * 6 + 1;
            float maxRange = (1 / (Mathf.Pow(3, ((Time.time - startTime) / 60)))) * 10 + 2;
            Debug.Log(minRange);
            Debug.Log(maxRange);
            startingPoint.position = playerCharacter.transform.position + new Vector3(startingPointOffset, 0, 0);
            float rnd = Random.Range(minRange, maxRange);
            
            var bird = Instantiate(birdInstance);
            bird.transform.position = startingPoint.position;
            Destroy(bird, 6f);
            //bird.transform.Translate(Vector3.left * birdSpeed * Time.deltaTime);
            Debug.Log(rnd);
            yield return new WaitForSeconds(rnd);
        }
	}
}
