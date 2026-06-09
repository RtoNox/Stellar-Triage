using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public GameObject enemyPrefab;

    [Header("Spawn Settings")]
    public float baseSpawnInterval = 2f;
    public float minSpawnInterval = 0.8f;
    public float spawnX = 11f; // Right side of screen
    public float minY = -4f;
    public float maxY = 4f;

    [Header("Difficulty Scaling")]
    public int maxEnemiesAtOnce = 5;
    public float spawnDistanceBuffer = 2f; // Prevent enemies spawning too close

    private float currentSpawnInterval;
    private float spawnTimer;
    private int currentEnemyCount = 0;

    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    void Update()
    {
        if (!MinigameManager.Instance.IsGameActive()) return;

        // Clean up destroyed enemies from count
        CleanUpEnemyCount();

        // Difficulty scaling based on time survived (0-3 minutes)
        float timeElapsed = 180f - MinigameManager.Instance.GetRemainingTime();
        float progress = Mathf.Clamp01(timeElapsed / 180f);
        currentSpawnInterval = Mathf.Lerp(baseSpawnInterval, minSpawnInterval, progress);

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f && currentEnemyCount < maxEnemiesAtOnce)
        {
            SpawnEnemy();
            spawnTimer = currentSpawnInterval;
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy Prefab not assigned in EnemySpawner!");
            return;
        }

        // Find a valid Y position (avoid overlapping with existing enemies)
        float yPos = Random.Range(minY, maxY);
        
        // Optional: Prevent spawn too close to other enemies
        if (!IsPositionSafe(yPos))
        {
            yPos = FindSafeYPosition();
        }

        Vector3 spawnPos = new Vector3(spawnX, yPos, 0f);
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        
        // Store reference to track count (enemy will remove itself when destroyed)
        EnemyDestructionHandler handler = enemy.GetComponent<EnemyDestructionHandler>();
        if (handler == null)
            handler = enemy.AddComponent<EnemyDestructionHandler>();
        
        handler.SetSpawner(this);
        
        currentEnemyCount++;
    }

    bool IsPositionSafe(float yPos)
    {
        // Check all existing enemies to avoid overlapping spawns
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distance = Mathf.Abs(enemy.transform.position.y - yPos);
            if (distance < spawnDistanceBuffer)
                return false;
        }
        return true;
    }

    float FindSafeYPosition()
    {
        for (int i = 0; i < 10; i++) // Try 10 times
        {
            float yPos = Random.Range(minY, maxY);
            if (IsPositionSafe(yPos))
                return yPos;
        }
        return Random.Range(minY, maxY); // Return random if all attempts fail
    }

    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }

    void CleanUpEnemyCount()
    {
        // Ensure count doesn't go negative and matches actual enemies
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentEnemyCount = enemies.Length;
    }
}