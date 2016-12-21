using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

	/// <summary>
	/// The button category.
	/// 0: big button menu;
	/// </summary>
	[SerializeField]
	int buttonCategory;



	Animator anim;
	AudioSource aus;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		aus = GetComponent<AudioSource> ();
	}


	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonDown(){
		anim.SetBool ("ButtonDown", true);
	}

	public void ButtonUp(){
		Debug.Log ("123");
		anim.SetBool ("ButtonDown", false);
		AudioPlay.PlaySound(aus, SoundLibrary.clipDictionary["bigButtonPress"]);
	}


}
