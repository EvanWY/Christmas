using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftImgManager : MonoBehaviour {
	public static GiftImgManager Instance;
	public float BlinkFrequency;

	public GiftImgSet[] giftImgSets;

	void Awake() {
		Instance = this;
	}

}

[Serializable]
public class GiftImgSet {
	public Sprite spr1;
	public Sprite spr2;
	public Sprite sprFin;
}