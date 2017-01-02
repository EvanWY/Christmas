using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float cycleDistance;
	public float cycleOffset;
	public float initOffset;
	Transform cameraTfm;

	// Use this for initialization
	void Start () {
        //rend = GetComponent<SpriteRenderer>();
		cameraTfm = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = Vector3.right * (cameraTfm.position.x + cycleOffset /2  + ((cameraTfm.position.x + initOffset) % cycleDistance) * (-(cycleOffset) / cycleDistance));
	}

}
