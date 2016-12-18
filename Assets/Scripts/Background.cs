using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float offsetSpeed;
    private SpriteRenderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float offset = Time.time * offsetSpeed;
        rend.material.mainTextureOffset = new Vector2(offset, 0);
	}
}
