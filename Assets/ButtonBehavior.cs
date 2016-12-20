using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ButtonDown(){
		anim.SetBool ("ButtonDown", true);
	}

	public void ButtonUp(){
		anim.SetBool ("ButtonDown", false);
	}


}
