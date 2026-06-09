using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float topBound = 4.5f;
    public float bottomBound = -4.5f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;
    public float bulletSpeed = 15f;

    private float nextFireTime = 0f;

    void Start()
    {
        if (firePoint == null)
            firePoint = transform;
    }

    void Update()
    {
        if (!MinigameManager.Instance.IsGameActive()) return;

        // Up / Down movement
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 newPos = transform.position + Vector3.up * vertical * moveSpeed * Time.deltaTime;
        newPos.y = Mathf.Clamp(newPos.y, bottomBound, topBound);
        transform.position = newPos;

        // Shooting (Space or Left Mouse)
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // ✅ FIXED: Use 'velocity' instead of 'linearVelocity'
            rb.velocity = Vector2.right * bulletSpeed;
        }

        Destroy(bullet, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid") || other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            MinigameManager.Instance.PlayerHit();
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            enabled = false;
        }
    }
}