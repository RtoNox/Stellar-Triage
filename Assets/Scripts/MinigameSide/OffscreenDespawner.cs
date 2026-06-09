using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenDespawner : MonoBehaviour
{
    public float leftBound = -12f;
    public float rightBound = 12f;
    public float topBound = 10f;
    public float bottomBound = -10f;

    void Update()
    {
        // Despawn if completely off-screen
        if (transform.position.x < leftBound || 
            transform.position.x > rightBound ||
            transform.position.y > topBound ||
            transform.position.y < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}