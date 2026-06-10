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

    [SerializeField] private Button JobOneY;
    [SerializeField] private Button JobOneN;
    [SerializeField] private Button JobTwoY;
    [SerializeField] private Button JobTwoN;
    [SerializeField] private Button JobThreeY;
    [SerializeField] private Button JobThreeN;
    [SerializeField] private Button JobFourY;
    [SerializeField] private Button JobFourN;

    public int oneStatus;
    public int twoStatus;
    public int threeStatus;
    public int fourStatus;

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
}
