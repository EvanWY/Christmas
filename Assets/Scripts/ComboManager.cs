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

    public static int highestComboNum;

	static int comboNum_Display;
	static AudioSource aus;
	static Animator anim_UI;
	static Text comboUI_static;
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
		AudioPlay.PlaySound (aus, SoundLibrary.clipDictionary["comboUp"]);
		comboUI_static.text = comboNum_Display.ToString () + "\n<size=96>combo</size>";
		comboUI_static.enabled = true;
		anim_UI.SetTrigger ("Up");
		//to do: play different clips based on current combo Num;
        
	}

	/// <summary>
	/// Call this method to break the combo.
	/// </summary>
	public static void ComboBreak(){
		//AudioPlay.PlaySound (aus, SoundLibrary.clipDictionary["comboBreak"]);

		if (comboNum_Display > 0) {
			anim_UI.SetTrigger ("Break");
		}
			
		currentComboNum = 0;
		reset = true;
	}

	// Use this for initialization
	void Awake () {
		aus = GetComponent<AudioSource> ();
		comboUI_static = comboUI; 
		comboUI.enabled = false;
		anim_UI = comboUI_static.GetComponent<Animator> ();
		currentComboNum = 0;
		highestComboNum = 0;
	}


	// Update is called once per frame
	void Update () {
		//Debug.Log ("Combo UI status: " + comboUI.enabled);
		if(Input.GetKeyDown(KeyCode.Q)){
			ComboManager.ComboUp ();
		}
		else if(Input.GetKeyDown(KeyCode.W)){
			ComboManager.ComboBreak ();
		}
		else if(Input.GetKeyDown(KeyCode.A)){
			Debug.Log ("Current Combo: " + ComboManager.currentComboNum);
		}

        if(highestComboNum <= currentComboNum)
        {
            highestComboNum = currentComboNum;
        }

	}
}
