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

    private float fiveSecondCheck;
    private float fiveSecond = 5.0f;

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
                    }
                    else if (jobCategory == 2)
                    {
                        DisableAllText();
                        CallNormal.SetActive(true);
                    }
                    else if (jobCategory == 3)
                    {
                        DisableAllText();
                        CallEmergency.SetActive(true);
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
        TextBox.SetActive(false);
        
        //Move job to left panel
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
