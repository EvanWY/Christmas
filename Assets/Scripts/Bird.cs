using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private float birdSpeed;
	public float startTime;

	public float minSpeed_factor;
	public float maxSpeed_factor;

	public AnimationCurve speedProb;

	public Collider2D cadanCol;
	public Collider2D birdCol;
	public float persistTime;

	[Tooltip("Position relative to the last created bird. Only used for 3rd birds")]
	protected bool isAbove;
	protected bool isRight;

	Rigidbody2D rigid;
	Animator anim;
	AudioSource aus;

	public void Awake(){
		aus = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();

	}

	void SetSpeed(){
		Random.InitState (gameObject.GetInstanceID());
		float minRange = (1 - 1 / (Mathf.Pow(3, (Time.time - startTime / 60)))) * minSpeed_factor + 1;
		float maxRange = (1 - 1 / (Mathf.Pow(3, (Time.time - startTime / 60)))) * maxSpeed_factor + 2;

		float scaledRange = maxRange - minRange;

		float x = UnityEngine.Random.Range (0f, 1f);
		maxRange = minRange + scaledRange * speedProb.Evaluate (x);
		birdSpeed = Random.Range(minRange, maxRange);
		//Debug.Log ("Bird speed: " + birdSpeed);
	}

	public void Initialize(float startTime){
		this.startTime = startTime;
		SetSpeed ();
		AudioPlay.PlaySound (aus, SoundLibrary.clipDictionary["birdFly"]);
		Destroy (gameObject, persistTime);
	}

	public void Initialize(float startTime, bool isAbove, bool isRight){
		Initialize (startTime);
		this.isAbove = isAbove;
		this.isRight = isRight;
	}



	// Update is called once per frame
	void Update () {

        this.transform.Translate(Vector3.left * birdSpeed * Time.deltaTime);
	}

	public void BirdGG(){
		if(!rigid)
			rigid = gameObject.AddComponent<Rigidbody2D> ();
		birdCol.isTrigger = false;
		anim.SetTrigger ("gg");
		cadanCol.enabled = false;
		AudioPlay.PlaySound (aus, SoundLibrary.clipDictionary["birdCadan"]);
	}

	/// <summary>
	/// Will be called After the bird deals damage.
	/// </summary>
	public void AfterDamage(){
		cadanCol.enabled = false;
	}
}

