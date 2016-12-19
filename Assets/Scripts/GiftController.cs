using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftController : MonoBehaviour {

	GiftImgSet imgSet;
	SpriteRenderer rend;

	bool isCollected;
	float frequency;
	
	void Start () {
		imgSet = GiftImgManager.Instance.giftImgSets.RandElement();
		frequency = GiftImgManager.Instance.BlinkFrequency;
		rend = GetComponent<SpriteRenderer>();
		isCollected = false;
	}

	float startTime = 0;
	bool isFirstImg = false;
	void Update () {
		if (!isCollected) {
			if (Time.time - startTime > frequency) {
				startTime = Time.time;
				rend.sprite = isFirstImg ? imgSet.spr1 : imgSet.spr2;
				isFirstImg = !isFirstImg;
			}
		}
		else {
			transform.parent.GetComponent<Animator>().SetTrigger("collected");
		}
	}

	public void Collected() {
		isCollected = true;
		rend.sprite = imgSet.sprFin;
	}
}
