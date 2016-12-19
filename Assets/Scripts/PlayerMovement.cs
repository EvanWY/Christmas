using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour {

    public float MaxVirticalSpeed;
    public float VirticalSpeed;
    public float TargetVirticalSpeed;
    public float SmoothTime;
    public float ForwardSpeed;
    public float FlashFrequency;
    public float InvincibleTime;
    public float Health;

    public float MaxHeight;
    public float MinHeight;
    public bool isInvincible;

    private BoxCollider2D bCollider;
    private SpriteRenderer[] sRenderer;

    public void OnTouchStart()
    {
        TargetVirticalSpeed = MaxVirticalSpeed;
    }

    public void OnTouchEnd()
    {
        TargetVirticalSpeed = -MaxVirticalSpeed;
    }

	float startTime = 0;
    void Start()
    {
        OnTouchEnd();

        bCollider = GetComponent<BoxCollider2D>();
        sRenderer = GetComponentsInChildren<SpriteRenderer>();

		startTime = Time.time;

	}

    float _tempVelocity;


	void Update () {

        var y = transform.position.y;
        var x = transform.position.x;

		if (Time.time - startTime > 4f)
			y = Mathf.Clamp(y + VirticalSpeed * Time.deltaTime, MinHeight, MaxHeight);
		else
			VirticalSpeed = 0;

		x = x + ForwardSpeed * Time.deltaTime;

        transform.position = new Vector3(x, y, transform.position.z);

        VirticalSpeed = Mathf.SmoothDamp(VirticalSpeed, TargetVirticalSpeed, ref _tempVelocity, SmoothTime);
	}




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isInvincible && collision.CompareTag("Obstacle"))
        {
            StartCoroutine(Invincible(InvincibleTime));
            ComboManager.ComboBreak();
            Debug.Log("Collide with house");
        }

        if (collision.CompareTag("Gift"))
        {
			//Destroy(collision.gameObject);
			collision.gameObject.GetComponent<GiftController>().Collected();

			ComboManager.ComboUp();
            Debug.Log("Gift delivered");
        }
    }



    IEnumerator Invincible(float duration)
    {
        //bCollider.enabled = false;
        isInvincible = true;
        var startTime = Time.time;
        while (Time.time - startTime < InvincibleTime)
        {
			foreach (var r in sRenderer) {
				r.color = new Color(1, 1, 1, 0.4f);
			}

            yield return new WaitForSeconds(FlashFrequency * 0.3f);

			foreach (var r in sRenderer) {
				r.color = new Color(1, 1, 1, 1f);
			}

			yield return new WaitForSeconds(FlashFrequency * 0.7f);
		}

		isInvincible = false;
    }
}
