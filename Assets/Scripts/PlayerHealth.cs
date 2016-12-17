using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    private SpriteRenderer sRenderer;
    public float initialHealth;
    public float damage;
    private float currentHealth;

	// Use this for initialization
	void Start () {
        currentHealth = initialHealth;
        sRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            currentHealth -= damage;
            Debug.Log("Collide with house, cause damage");
        }
    }
}
