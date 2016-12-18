using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Manages the combo system and UI
public class ComboManager : MonoBehaviour {
	[Header("Variables to be configured")]
	[SerializeField]
	AudioClip[] comboUpSounds;
	[SerializeField]
	AudioClip comboBreakSound;
	[SerializeField]
	Text comboUI;

	/// <summary>
	/// The current combo number.
	/// </summary>
	public static int currentComboNum;
	static AudioSource aus;
	static Animator anim_UI;
	static Text comboUI_static;
	static AudioClip[] comboUpSounds_static;
	static AudioClip comboBreakSound_static;

	/// <summary>
	/// Call this method to increase the current combo by 1.
	/// </summary>
	public static void ComboUp(){
		currentComboNum += 1;
		AudioPlay.PlaySound (aus, comboUpSounds_static [0]);
		comboUI_static.text = currentComboNum.ToString ();
		comboUI_static.enabled = true;
		anim_UI.SetTrigger ("Up");
		//to do: play different clips based on current combo Num;
	}

	/// <summary>
	/// Call this method to break the combo.
	/// </summary>
	public static void ComboBreak(){
		currentComboNum = 0;
		AudioPlay.PlaySound (aus, comboBreakSound_static);
		comboUI_static.text = currentComboNum.ToString ();
		comboUI_static.enabled = false;
		anim_UI.SetTrigger ("Break");
	}

	// Use this for initialization
	void Awake () {
		aus = GetComponent<AudioSource> ();
		comboUpSounds_static = comboUpSounds;
		comboBreakSound_static = comboBreakSound;
		comboUI_static = comboUI; 
		anim_UI = comboUI_static.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Q)){
			ComboManager.ComboUp ();
		}
		else if(Input.GetKeyDown(KeyCode.W)){
			ComboManager.ComboBreak ();
		}
	}
}
