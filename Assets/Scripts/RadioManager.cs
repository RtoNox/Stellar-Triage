using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Radiomanager : MonoBehaviour
{
    public UnityEvent OnClickInteraction;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject Radio;
    [SerializeField] private GameObject PopUp;
    [SerializeField] private GameObject TextBox;
    [SerializeField] private GameObject CallPrank;
    [SerializeField] private GameObject CallNormal;
    [SerializeField] private GameObject CallEmergency;
    private PolygonCollider2D polyCollider;
    public JobHandler jobHandlerRef;

    private float fiveSecondCheck;
    private float fiveSecond = 5.0f;

    public int jobCurrent;

    private void Start()
    {
        polyCollider = Radio.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        float previousTime = fiveSecondCheck;
        fiveSecondCheck += Time.deltaTime;
        
        if (previousTime < fiveSecond && fiveSecondCheck >= fiveSecond)
        {
            int radioCheck = Random.Range(1, 3); //nanti ganti ke 1, 11
            if (radioCheck == 1)
            {
                if (polyCollider.enabled == false && TextBox.activeSelf == false)
                {
                    Debug.Log($"roll 1");
                    polyCollider.enabled = !polyCollider.enabled;
                    PopUp.SetActive(true);

                    int jobCategory = Random.Range(1, 4);
                    if (jobCategory == 1)
                    {
                        DisableAllText();
                        CallPrank.SetActive(true);
                        jobCurrent = 1;
                    }
                    else if (jobCategory == 2)
                    {
                        DisableAllText();
                        CallNormal.SetActive(true);
                        jobCurrent = 2;
                    }
                    else if (jobCategory == 3)
                    {
                        DisableAllText();
                        CallEmergency.SetActive(true);
                        jobCurrent = 3;
                    }
                }
            }
            else
            {
                Debug.Log($"roll 2");
            }

        }
        fiveSecondCheck %= fiveSecond;
    }

    private void OnMouseDown()
    {
        TriggerInteraction();
    }

    public void NextButton()
    {
        DisableAllText();
        TextBox.SetActive(false);
        
        if (jobHandlerRef.JobOne.activeSelf == false)
        {
            jobHandlerRef.JobOne.SetActive(true);
        }
        else if (jobHandlerRef.JobTwo.activeSelf == false)
        {
            jobHandlerRef.JobTwo.SetActive(true);
        }
        else if (jobHandlerRef.JobThree.activeSelf == false)
        {
            jobHandlerRef.JobThree.SetActive(true);
        }
        else if (jobHandlerRef.JobFour.activeSelf == false)
        {
            jobHandlerRef.JobFour.SetActive(true);
        }
    }

    public void TriggerInteraction()
    {
        Debug.Log($"radio click");
        polyCollider.enabled = !polyCollider.enabled;
        PopUp.SetActive(false);
        TextBox.SetActive(true);
        OnClickInteraction?.Invoke(); 
    }

    private void DisableAllText()
    {
        CallPrank.SetActive(false);
        CallNormal.SetActive(false);
        CallEmergency.SetActive(false);
    }
}
