using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        TriggerObjectBehavior();
    }

    private void TriggerObjectBehavior()
    {
        Debug.Log($"Clicked on: {gameObject.name}");
    }
}
