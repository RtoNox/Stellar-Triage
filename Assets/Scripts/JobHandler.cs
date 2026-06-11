using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class JobHandler : MonoBehaviour
{
    public GameObject JobOne;
    public GameObject JobTwo;
    public GameObject JobThree;
    public GameObject JobFour;
    public GameObject ProgressOne;
    public GameObject ProgressTwo;
    public GameObject ProgressThree;
    public GameObject ProgressFour;

    // [SerializeField] private Button JobOneY;
    // [SerializeField] private Button JobOneN;
    // [SerializeField] private Button JobTwoY;
    // [SerializeField] private Button JobTwoN;
    // [SerializeField] private Button JobThreeY;
    // [SerializeField] private Button JobThreeN;
    // [SerializeField] private Button JobFourY;
    // [SerializeField] private Button JobFourN;

    public int oneStatus;
    public int twoStatus;
    public int threeStatus;
    public int fourStatus;
    // public int oneBar;
    // public int twoBar;
    // public int threeBar;
    // public int fourBar;

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void AcceptJobOne()
    {
        JobOne.SetActive(false);
        Debug.Log($"acc 1");

        // Move to middle screen
        ProgressOne.SetActive(true);
    }
    public void DeclineJobOne()
    {
        JobOne.SetActive(false);
        Debug.Log($"dec 1");
    }

    public void AcceptJobTwo()
    {
        JobTwo.SetActive(false);
        Debug.Log($"acc 2");

        // Move to middle screen
        ProgressTwo.SetActive(true);
    }
    public void DeclineJobTwo()
    {
        JobTwo.SetActive(false);
        Debug.Log($"dec 2");
    }

    public void AcceptJobThree()
    {
        JobThree.SetActive(false);
        Debug.Log($"acc 3");

        // Move to middle screen
        ProgressThree.SetActive(true);
    }
    public void DeclineJobThree()
    {
        JobThree.SetActive(false);
        Debug.Log($"dec 3");
    }

    public void AcceptJobFour()
    {
        JobFour.SetActive(false);
        Debug.Log($"acc 4");

        // Move to middle screen
        ProgressFour.SetActive(true);
    }
    public void DeclineJobFour()
    {
        JobFour.SetActive(false);
        Debug.Log($"dec 4");
    }

    public void HideBarOne()
    {
        ProgressOne.SetActive(false);
    }
    public void HideBarTwo()
    {
        ProgressTwo.SetActive(false);
    }
    public void HideBarThree()
    {
        ProgressThree.SetActive(false);
    }
    public void HideBarFour()
    {
        ProgressFour.SetActive(false);
    }

    // private void DisableJobOneButton()
    // {
    //     JobOneY.interactable = false;
    //     JobOneN.interactable = false;
    // }
    // private void DisableJobTwoButton()
    // {
    //     JobTwoY.interactable = false;
    //     JobTwoN.interactable = false;
    // }
    // private void DisableJobThreeButton()
    // {
    //     JobThreeY.interactable = false;
    //     JobThreeN.interactable = false;
    // }
    // private void DisableJobFourButton()
    // {
    //     JobFourY.interactable = false;
    //     JobFourN.interactable = false;
    // }
}
