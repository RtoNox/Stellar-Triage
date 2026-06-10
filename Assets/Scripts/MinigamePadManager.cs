using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MinigamePadManager : MonoBehaviour
{
    public UnityEvent OnClickInteraction;
    private SpriteRenderer spriteRenderer;

    private void OnMouseDown()
    {
        TriggerInteraction();
    }

    public void TriggerInteraction()
    {
        Debug.Log($"pad click");
        OnClickInteraction?.Invoke(); 
    }
}
