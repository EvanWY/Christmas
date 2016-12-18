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
    private bool isInvinciblePM;
    private float halfHealth;

	// Use this for initialization
	void Start () {
        currentHealth = initialHealth;
        sRenderer = GetComponentInChildren<SpriteRenderer>();
        invincibleT = pm.InvincibleTime;
        halfHealth = initialHealth / 2.0f;

		StartCoroutine(RegenerateHealth());
	}
	
	// Update is called once per frame
	void Update () {

        isInvinciblePM = pm.isInvincible;
        if(currentHealth < 0f)
        {
            GameOver();
        }

        //if(currentHealth >= initialHealth)
        //{
        //    //Debug.Log("perfect state");
        //}

        //if( halfHealth <= currentHealth && currentHealth < initialHealth)
        //{
        //    //Debug.Log("First hit");
        //}

        //if(0f < currentHealth && currentHealth < halfHealth){
        //    //Debug.Log("Second hit");
        //}
		//Debug.Log(currentHealth);

		GetComponent<Animator>().SetFloat("hp", currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvinciblePM && collision.CompareTag("Obstacle"))
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
		for (; ;) {
			yield return new WaitForSeconds(1f);
			if (!isDamaged) {
				currentHealth += addHealth;
				if (currentHealth > initialHealth)
					currentHealth = initialHealth;
			}
		}
    }
}
