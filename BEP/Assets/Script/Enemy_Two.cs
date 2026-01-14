using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_two : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 3f;
    public float detectionRange = 5f;
    public int damage = 10;

    private Transform target;

    void Start()
    {
        target = pointA;
    }

    void Update()
    {
        float dist = Vector2.Distance(transform.position, player.position);

        if (dist <= detectionRange)
        {
            Move(player.position, chaseSpeed);
        }
        else
        {
            Move(target.position, patrolSpeed);

            if (Vector2.Distance(transform.position, target.position) < 0.1f)
                target = target == pointA ? pointB : pointA;
        }
    }

    void Move(Vector2 targetPos, float speed)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );
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
