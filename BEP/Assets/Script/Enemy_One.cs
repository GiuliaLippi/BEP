using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_one : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public int damage = 10;

    private Transform target;

    void Start()
    {
        target = pointA;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
            target = target == pointA ? pointB : pointA;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMovementt player = col.gameObject.GetComponent<PlayerMovementt>();
            if (player)
                player.TakeDamage(damage);
        }
    }
}
