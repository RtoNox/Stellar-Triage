using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructionHandler : MonoBehaviour
{
    private EnemySpawner spawner;

    public void SetSpawner(EnemySpawner enemySpawner)
    {
        spawner = enemySpawner;
    }

    void OnDestroy()
    {
        if (spawner != null)
        {
            spawner.EnemyDestroyed();
        }
    }
}