using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    public float speed, minDistance;
    private Transform target;

    private bool chase;
    private Vector2 vecTarget, direction;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (chase && target != null)
        {
            if (Vector2.Distance(transform.position, target.position) <= minDistance)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    public void ChaseTransform(Transform targetTransform)
    {
        target = targetTransform;
        direction = ((Vector2)target.position - (Vector2)transform.position).normalized;

        rb.velocity = direction * speed;

        chase = true;
    }

    public void ChaseTarget(Vector2 target)
    {
        this.vecTarget = target;
        direction = target - (Vector2)transform.position;

        rb.velocity = direction * speed;

        chase = true;
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}