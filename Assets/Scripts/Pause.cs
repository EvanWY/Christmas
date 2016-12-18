using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool isPaused;
    public PlayerMovement pm;
    public GameObject count3;
    public GameObject count2;
    public GameObject count1;
    public GameObject go;

    public float GameTime;

    private float pausedTime;
    private Background[] bg;

    void Start()
    {
        bg = GetComponentsInChildren<Background>();
    }

	void Update () {

        if (Input.GetKeyDown("space"))
        {
            if (!isPaused)
            {
                pm.enabled = false;
                for (int i = 0; i < bg.Length; i++)
                {
                    bg[i].enabled = false;
                }
                isPaused = true;
            }else
            {
                isPaused = false;
                StartCoroutine(CountDown());
            }
        }
   }

    IEnumerator CountDown()
    {
        //count3.SetActive(true);
        //yield return new WaitForSeconds(1);

        //count3.SetActive(false);
        //count2.SetActive(true);
        //yield return new WaitForSeconds(1);

        //count2.SetActive(false);
        //count1.SetActive(true);
        //yield return new WaitForSeconds(1);

        //count1.SetActive(false);
        //go.SetActive(true);

        //yield return new WaitForSeconds(1);
        //go.SetActive(false);

        yield return new WaitForSeconds(3f);

        for (int i = 0; i < bg.Length; i++)
        {
            bg[i].enabled = true;
        }
        pm.enabled = true;

    }
}
