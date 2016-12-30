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

	[Header("For touch to move to pos")]
	public float speed;
	Vector3 touchPos;
	bool touching;

    public void OnTouchStart()
    {
        TargetVirticalSpeed = MaxVirticalSpeed;

		//move to touch position
		touching = true;
    }

    public void OnTouchEnd()
    {
        TargetVirticalSpeed = -MaxVirticalSpeed;

		//move to touch position
		touching = false;
    }

	float startTime = 0;
    
	void Start()
    {
		Input.simulateMouseWithTouches = true;
        OnTouchEnd();

        bCollider = GetComponent<BoxCollider2D>();
        sRenderer = GetComponentsInChildren<SpriteRenderer>();

		startTime = Time.time;

	}

    float _tempVelocity;


	void Update () {
		TouchToMoveUp ();

	}

	void TouchToMoveTowards(){
		if(touching && Input.touchCount > 0)
		{
			Vector3 touchPos = Input.GetTouch (0).position;
			Debug.Log (touchPos);
			Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

			Vector3 dir = touchPos - playerPos;
			Vector3 dest = transform.position + dir;
			Debug.DrawLine (transform.position, dest);
			transform.position = Vector3.MoveTowards (transform.position, dest, speed * Time.deltaTime);
		}


	}

	void TouchToMoveUp(){
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
		//Debug.Log (collision.name);

        if (!isInvincible && collision.CompareTag("Obstacle"))
        {
            StartCoroutine(Invincible(InvincibleTime));
			if(collision.name.Contains("Bird")){
				collision.GetComponent<BirdFly> ().AfterDamage ();
			}
            ComboManager.ComboBreak();
            Debug.Log("Collide with house");
        }

        if (collision.CompareTag("Gift"))
        {
			//Destroy(collision.gameObject);
			collision.gameObject.GetComponent<GiftController>().Collected();
			GiftManager.GiftSentNum++;
			TimeManager.AddTime (3.5f);
			ComboManager.ComboUp();
            //Debug.Log("Gift delivered");
        }

		if (collision.CompareTag("Cadan"))
		{
			//Destroy(collision.gameObject);
			collision.transform.parent.GetComponent<BirdFly>().BirdGG();
			TimeManager.AddTime (3.5f);
			ComboManager.ComboUp();
			//Debug.Log("Gift delivered");
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
