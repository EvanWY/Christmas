using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public bool isDamaged;
    public float initialHealth = 10f;
    public float damage;
    public float addHealth;
    public PlayerMovement pm;

    private SpriteRenderer sRenderer;
    private float currentHealth;
    private float invincibleT;

	// Use this for initialization
	void Start () {
        currentHealth = initialHealth;
        sRenderer = GetComponentInChildren<SpriteRenderer>();
        invincibleT = pm.InvincibleTime;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentHealth <= 0f)
        {
            GameOver();
        }

        StartCoroutine(RegenerateHealth());
        Debug.Log(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            isDamaged = true;
            currentHealth -= damage;
            Debug.Log("Collide with house, cause damage");
            //Debug.Log(currentHealth);
            StartCoroutine(BackFromInvincible(invincibleT));
        }
    }

    private void GameOver()
    {
        Debug.Log("Game over");
    }

    IEnumerator BackFromInvincible(float duration)
    {
        yield return new WaitForSeconds(duration);
        isDamaged = false;
    }

    IEnumerator RegenerateHealth()
    {
        yield return new WaitForSeconds(1f);
        if(!isDamaged && currentHealth < initialHealth)
        {
            currentHealth += addHealth;
        }
    }
}
