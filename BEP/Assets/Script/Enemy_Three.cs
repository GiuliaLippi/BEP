using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_three : MonoBehaviour
{
    public Transform player;
    public GameObject projectilePrefab;

    public float detectionRange = 6f;
    public float fireRate = 1f;
    public float projectileSpeed = 5f;
    public int damage = 10;

    private float fireCooldown;

    void Update()
    {
        if (!player) return;

        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectionRange && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }

        fireCooldown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        Vector2 dir = (player.position - transform.position).normalized;
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        if (rb)
            rb.velocity = dir * projectileSpeed;

        Projectile p = proj.GetComponent<Projectile>();
        if (p)
            p.damage = damage;
    }
}
