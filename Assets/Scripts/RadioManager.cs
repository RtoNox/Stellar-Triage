using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine;

public class Radiomanager : MonoBehaviour
{
    public UnityEvent OnClickInteraction;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject Radio;
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
            int eventIndex = Random.Range(1, 3);
            if (eventIndex == 1)
            {
                if (polyCollider.enabled == false)
                {
                    Debug.Log($"roll 1");
                    polyCollider.enabled = !polyCollider.enabled;
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

    public void TriggerInteraction()
    {
        Debug.Log($"radio click");
        polyCollider.enabled = !polyCollider.enabled;
        OnClickInteraction?.Invoke(); 
    }
}
