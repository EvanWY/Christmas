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

	public static float currentTimer;
	public static Text timeUI_static;

	// Use this for initialization
	void Awake () {
		currentTimer = 10.00f;
		timeUI_static = timeUI;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentTimer > 0){
			currentTimer -= Time.deltaTime;
		}
		timeUI_static.text = currentTimer.ToString ();
	}

	public static void AddTime(float time){
		currentTimer += time;
	}

	void StartTimer(){


	}


	void ResetTimer(){

	}
}
