using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSFXController : MonoBehaviour {

	AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource>();
	}

	public void PlayNum3SFX() {
		AudioPlay.PlaySound (audioSource, SoundLibrary.clipDictionary["countDown3"]);
	}	

	public void PlayNum2SFX() {
		AudioPlay.PlaySound (audioSource, SoundLibrary.clipDictionary["countDown2"]);
	}	

	public void PlayNum1SFX() {
		AudioPlay.PlaySound (audioSource, SoundLibrary.clipDictionary["countDown1"]);
	}

	public void PlayGOSFX() {
		AudioPlay.PlaySound (audioSource, SoundLibrary.clipDictionary["countDownGo"]);
	}
}
