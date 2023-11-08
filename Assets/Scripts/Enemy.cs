using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Waypoint1;
    public GameObject Waypoint2;
    private Transform currentPoint;
    public float Speed = 2;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = Waypoint2.transform;
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == Waypoint2.transform)
        {
            rb.velocity = new Vector2(Speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-Speed, 0);
        }

        if(Vector2.Distance(transform.position , currentPoint.position) < 0.5 && currentPoint == Waypoint2.transform)
        {
            flip();
            currentPoint = Waypoint1.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5 && currentPoint == Waypoint1.transform)
        {
            flip();
            currentPoint = Waypoint2.transform;
        }
    }

    void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
