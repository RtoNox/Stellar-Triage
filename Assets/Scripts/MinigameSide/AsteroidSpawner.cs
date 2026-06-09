using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Asteroid Prefab")]
    public GameObject asteroidPrefab;

    [Header("Spawn Settings")]
    public float baseSpawnInterval = 1.2f;
    public float minSpawnInterval = 0.5f;
    public float spawnX = 11f; // Right side of screen
    public float minY = -4.5f;
    public float maxY = 4.5f;

    [Header("Movement")]
    public float baseAsteroidSpeed = 5f;
    public float maxAsteroidSpeed = 12f;

    [Header("Spawning")]
    public int maxAsteroidsAtOnce = 8;
    public float minSpawnDistance = 1.5f; // Prevent overlapping

    private float currentSpawnInterval;
    private float currentAsteroidSpeed;
    private float spawnTimer;

    void Start()
    {
        currentSpawnInterval = baseSpawnInterval;
        currentAsteroidSpeed = baseAsteroidSpeed;
        spawnTimer = currentSpawnInterval;
    }

    void Update()
    {
        if (!MinigameSideManager.Instance.IsGameActive()) return;

        // Difficulty scaling based on time survived (0-3 minutes)
        float timeElapsed = 180f - MinigameSideManager.Instance.GetRemainingTime();
        float progress = Mathf.Clamp01(timeElapsed / 180f);
        
        currentSpawnInterval = Mathf.Lerp(baseSpawnInterval, minSpawnInterval, progress);
        currentAsteroidSpeed = Mathf.Lerp(baseAsteroidSpeed, maxAsteroidSpeed, progress);

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f && GetCurrentAsteroidCount() < maxAsteroidsAtOnce)
        {
            SpawnAsteroid();
            spawnTimer = currentSpawnInterval;
        }
    }

    void SpawnAsteroid()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogError("Asteroid Prefab not assigned in AsteroidSpawner!");
            return;
        }

        // Find safe Y position
        float yPos = FindSafeYPosition();
        
        Vector3 spawnPos = new Vector3(spawnX, yPos, 0f);
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.left * currentAsteroidSpeed;
        }

        // Add despawn handler
        OffscreenDespawner despawner = asteroid.GetComponent<OffscreenDespawner>();
        if (despawner == null)
            asteroid.AddComponent<OffscreenDespawner>();
        
        Destroy(asteroid, 15f); // Safety cleanup
    }

    int GetCurrentAsteroidCount()
    {
        return GameObject.FindGameObjectsWithTag("Asteroid").Length;
    }

    bool IsPositionSafe(float yPos)
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        foreach (GameObject ast in asteroids)
        {
            float distance = Mathf.Abs(ast.transform.position.y - yPos);
            if (distance < minSpawnDistance)
                return false;
        }
        return true;
    }

    float FindSafeYPosition()
    {
        for (int i = 0; i < 10; i++)
        {
            float yPos = Random.Range(minY, maxY);
            if (IsPositionSafe(yPos))
                return yPos;
        }
        return Random.Range(minY, maxY);
    }
}