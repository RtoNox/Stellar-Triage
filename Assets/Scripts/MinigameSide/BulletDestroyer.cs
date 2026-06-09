using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    public float leftBound = -12f;
    public float rightBound = 12f;

    void Update()
    {
        if (transform.position.x < leftBound || transform.position.x > rightBound)
            Destroy(gameObject);
    }
}