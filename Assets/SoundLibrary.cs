using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour {

	[Header("Menu Scene UI")]
	[Tooltip("Start and How to play")]
	public AudioClip bigButtonPress;
	public AudioClip nextPagePress;
	public AudioClip closeButton;

	[Header("Game Scene")]
	[Tooltip("taken 0 damage")]
	public AudioClip santaFly0;
	[Tooltip("taken 1 damage")]
	public AudioClip santaFly1;
	[Tooltip("taken 2 damage")]
	public AudioClip santaFly2;
	public AudioClip santaDamaged;
	public AudioClip presentDelivered;

	public AudioClip birdFly;

	[Header("Game Scene UI")]
	public AudioClip pauseButton;
	public AudioClip comboUp;
	public AudioClip comboBreak;
	public AudioClip countDown3;
	public AudioClip countDown2;
	public AudioClip countDown1;
	public AudioClip countDownGo;

	public static Dictionary<string, AudioClip> clipDictionary;

	// Use this for initialization
	void Start () {
		
		PopulateDic ();
	}

	void PopulateDic(){
		clipDictionary = new Dictionary<string, AudioClip> ();
		clipDictionary ["bigButtonPress"] = bigButtonPress;
		clipDictionary ["nextPagePress"] = nextPagePress;
		clipDictionary ["closeButton"] = closeButton;
		clipDictionary ["pauseButton"] = pauseButton;

		clipDictionary ["countDown3"] = countDown3;
		clipDictionary ["countDown2"] = countDown2;
		clipDictionary ["countDown1"] = countDown1;
		clipDictionary ["countDownGo"] = countDownGo;

		clipDictionary ["comboUp"] = comboUp;
		clipDictionary ["comboBreak"] = comboBreak;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
