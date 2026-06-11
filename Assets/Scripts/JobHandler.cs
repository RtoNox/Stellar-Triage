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

    [SerializeField] private Button JobOneY;
    [SerializeField] private Button JobOneN;
    [SerializeField] private Button JobTwoY;
    [SerializeField] private Button JobTwoN;
    [SerializeField] private Button JobThreeY;
    [SerializeField] private Button JobThreeN;
    [SerializeField] private Button JobFourY;
    [SerializeField] private Button JobFourN;
    // [SerializeField] private GameObject DoneOne;
    // [SerializeField] private Ga DoneTwo;
    // [SerializeField] private Button DoneThree;
    // [SerializeField] private Button DoneFour;

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
        DisableJobOneButton();
        Debug.Log($"acc 1");

        // Move to middle screen
        ProgressOne.SetActive(true);
    }
    public void DeclineJobOne()
    {
        EnableJobOneButton();
        JobOne.SetActive(false);
        Debug.Log($"dec 1");
    }

    public void AcceptJobTwo()
    {
        DisableJobTwoButton();
        Debug.Log($"acc 2");

        // Move to middle screen
        ProgressTwo.SetActive(true);
    }
    public void DeclineJobTwo()
    {
        EnableJobTwoButton();
        JobTwo.SetActive(false);
        Debug.Log($"dec 2");
    }

    public void AcceptJobThree()
    {
        DisableJobThreeButton();
        Debug.Log($"acc 3");

        // Move to middle screen
        ProgressThree.SetActive(true);
    }
    public void DeclineJobThree()
    {
        EnableJobThreeButton();
        JobThree.SetActive(false);
        Debug.Log($"dec 3");
    }

    public void AcceptJobFour()
    {
        DisableJobFourButton();
        Debug.Log($"acc 4");

        // Move to middle screen
        ProgressFour.SetActive(true);
    }
    public void DeclineJobFour()
    {
        EnableJobFourButton();
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

    private void DisableJobOneButton()
    {
        JobOneY.interactable = false;
        JobOneN.interactable = false;
    }
    private void DisableJobTwoButton()
    {
        JobTwoY.interactable = false;
        JobTwoN.interactable = false;
    }
    private void DisableJobThreeButton()
    {
        JobThreeY.interactable = false;
        JobThreeN.interactable = false;
    }
    private void DisableJobFourButton()
    {
        JobFourY.interactable = false;
        JobFourN.interactable = false;
    }

    private void EnableJobOneButton()
    {
        JobOneY.interactable = true;
        JobOneN.interactable = true;
    }
    private void EnableJobTwoButton()
    {
        JobTwoY.interactable = true;
        JobTwoN.interactable = true;
    }
    private void EnableJobThreeButton()
    {
        JobThreeY.interactable = true;
        JobThreeN.interactable = true;
    }
    private void EnableJobFourButton()
    {
        JobFourY.interactable = true;
        JobFourN.interactable = true;
    }
}
