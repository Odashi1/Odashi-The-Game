using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 5f;

    private void Update()
    {
        if (Vector2.Distance(wayPoints[currentWaypointIndex].transform.position, transform.position) < .1) 
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
