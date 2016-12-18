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


	static int comboNum_Display;
	static AudioSource aus;
	static Animator anim_UI;
	static Text comboUI_static;
	static AudioClip[] comboUpSounds_static;
	static AudioClip comboBreakSound_static;
	static bool reset;

	/// <summary>
	/// Call this method to increase the current combo by 1.
	/// </summary>
	public static void ComboUp(){
		if (reset) {
			reset = false;
			comboNum_Display = 0;
		}
			
		comboNum_Display += 1;
		currentComboNum += 1;
		AudioPlay.PlaySound (aus, comboUpSounds_static [0]);
		comboUI_static.text = comboNum_Display.ToString ();
		comboUI_static.enabled = true;
		anim_UI.SetTrigger ("Up");
		//to do: play different clips based on current combo Num;
	}

	/// <summary>
	/// Call this method to break the combo.
	/// </summary>
	public static void ComboBreak(){
		if (comboNum_Display > 0) {
			anim_UI.SetTrigger ("Break");
			AudioPlay.PlaySound (aus, comboBreakSound_static);
		}
			
		currentComboNum = 0;
		reset = true;
	}

	// Use this for initialization
	void Awake () {
		aus = GetComponent<AudioSource> ();
		comboUpSounds_static = comboUpSounds;
		comboBreakSound_static = comboBreakSound;
		comboUI_static = comboUI; 
		comboUI.enabled = false;
		anim_UI = comboUI_static.GetComponent<Animator> ();
	}


	// Update is called once per frame
	void Update () {
		Debug.Log ("Combo UI status: " + comboUI.enabled);
		if(Input.GetKeyDown(KeyCode.Q)){
			ComboManager.ComboUp ();
		}
		else if(Input.GetKeyDown(KeyCode.W)){
			ComboManager.ComboBreak ();
		}
		else if(Input.GetKeyDown(KeyCode.A)){
			Debug.Log ("Current Combo: " + ComboManager.currentComboNum);
		}

	}
}
