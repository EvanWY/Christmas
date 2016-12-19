using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject tutorialPanel;
    public GameObject nextPageButtom;
    public GameObject previousPageButtom;

    private GameObject currentPage;
    private GameObject nextPage;
    private GameObject previousPage;
    public bool tutorialActivated;
    public GameObject[] tutorialPages;

    private Vector3 originalPosition;
    public int currentPageNum;
	// Use this for initialization
	void Start () {
        currentPageNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (tutorialActivated)
        {
            if(currentPageNum == 2)
            {
                nextPageButtom.SetActive(false);
            }
            else
            {
                nextPageButtom.SetActive(true);
            }

            if(currentPageNum == 0)
            {
                previousPageButtom.SetActive(false);
            }else
            {
                previousPageButtom.SetActive(true);
            }
        }
	}

    public void OpenTutorial()
    {
        tutorialPanel.SetActive(true);
        tutorialActivated = true;
        tutorialPages[0].SetActive(true);
        tutorialPages[1].SetActive(false);
        tutorialPages[2].SetActive(false);
        //tutorialPages[3].SetActive(false);
        currentPage = tutorialPages[0];
        currentPageNum = 0;
    }

    public void CloseTutorial()
    {
        tutorialPanel.SetActive(false);
        tutorialActivated = false;
    }

    public void NextPage()
    {
        if (!tutorialActivated)
        {
            Debug.Log("Tutorial not opened!");
        }

        if (tutorialActivated)
        {
            currentPage.GetComponent<Animator>().SetTrigger("NextPage");

            //currentPage.SetActive(false);
            currentPageNum++;
            tutorialPages[currentPageNum].SetActive(true);
            currentPage = tutorialPages[currentPageNum];
        }
    }

    public void PreviousPage()
    {
        if (!tutorialActivated)
        {
            Debug.Log("Tutorial not opened!");
        }

        if (tutorialActivated)
        {
            tutorialPages[currentPageNum - 1].GetComponent<Animator>().SetTrigger("PreviousPage");
            currentPageNum--;
            currentPage = tutorialPages[currentPageNum];
        }
    }
}
