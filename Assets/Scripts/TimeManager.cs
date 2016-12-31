using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

	class Timer : MonoBehaviour{
		float currentTime;

		public Timer(float time){
			currentTime = time;
		}

		public void Run(){
			StartCoroutine ("Running");
		}

		IEnumerator Running(){
			while(currentTime > 0){
				currentTime -= Time.fixedDeltaTime;

				yield return new WaitForFixedUpdate ();
			}
		}
	}

	[SerializeField]
	Text timeUI;

	public AnimationCurve curve;
	public float timeSpeed;
	public float initialTime;
	public static float currentTimer;
	public static Text timeUI_static;

	float elipsedTime;


	// Use this for initialization
	void Awake () {
		elipsedTime = 0;
		currentTimer = initialTime;
		timeUI_static = timeUI;
	}
	
	// Update is called once per frame
	void Update () {
		//calculate elipsed time
		elipsedTime += Time.deltaTime;
		float elipsedMin = elipsedTime / 60;
		timeSpeed = curve.Evaluate (elipsedMin);

		if (currentTimer > 0) {
			currentTimer -= Time.deltaTime * timeSpeed;
		} else {
			currentTimer = 0;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ().Die ();
		}
		timeUI_static.text = currentTimer.ToString ("0.00");
	}

	public static void AddTime(float time){
		currentTimer += time;
	}
		

	void StartTimer(){


	}


	void ResetTimer(){

	}
}
