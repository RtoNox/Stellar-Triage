using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float baseMoveSpeed = 3f;
    public float maxMoveSpeed = 7f;
    public float leftBound = -11f; // Despawn when past left side

    [Header("Shooting")]
    public GameObject enemyBulletPrefab;
    public Transform shootPoint;
    public float baseShootInterval = 1.5f;
    public float minShootInterval = 0.6f;

    private float currentShootInterval;
    private float currentMoveSpeed;
    private float shootTimer;

    void Start()
    {
        currentShootInterval = baseShootInterval;
        currentMoveSpeed = baseMoveSpeed;
        shootTimer = currentShootInterval;
        
        if (shootPoint == null) 
            shootPoint = transform;
    }

    void Update()
    {
        if (!MinigameManager.Instance.IsGameActive()) return;

        // Increase difficulty over time (0-3 minutes)
        float timeElapsed = 180f - MinigameManager.Instance.GetRemainingTime();
        float progress = Mathf.Clamp01(timeElapsed / 180f);
        
        currentMoveSpeed = Mathf.Lerp(baseMoveSpeed, maxMoveSpeed, progress);
        currentShootInterval = Mathf.Lerp(baseShootInterval, minShootInterval, progress);

        // Move LEFT (from right to left)
        transform.Translate(Vector2.left * currentMoveSpeed * Time.deltaTime);

        // Despawn when off-screen (past left bound)
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }

        // Shooting
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShootAtPlayer();
            shootTimer = currentShootInterval;
        }
    }

    void ShootAtPlayer()
    {
        if (enemyBulletPrefab == null) return;

        GameObject bullet = Instantiate(enemyBulletPrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Bullet speed increases with difficulty
            float timeElapsed = 180f - MinigameManager.Instance.GetRemainingTime();
            float progress = Mathf.Clamp01(timeElapsed / 180f);
            float bulletSpeed = Mathf.Lerp(8f, 15f, progress);
            rb.velocity = Vector2.left * bulletSpeed;
        }
        Destroy(bullet, 4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Enemy dies when hit by player bullet
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}