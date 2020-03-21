using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int speed;

    private GameObject[] waypoints;
    private GameObject finalWaypoint;
    private int waypointIndex;
    private Vector2 currentWaypoint;

    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        currentWaypoint = waypoints[waypointIndex].transform.position;
        RotateTowards(currentWaypoint);
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPosition(currentWaypoint);
        if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex < waypoints.Length - 1)
        {
            waypointIndex++;
            currentWaypoint = waypoints[waypointIndex].transform.position;
            RotateTowards(currentWaypoint);
        }
        else if (Vector2.Distance(transform.position, currentWaypoint) < 0.01 && waypointIndex == waypoints.Length - 1)
        {
            currentWaypoint = finalWaypoint.transform.position;
            RotateTowards(currentWaypoint);
        }
    }

    public void SetWaypoints(GameObject[] waypointObjects)
    {
        waypoints = waypointObjects;
    }

    public void SetFinalWaypoint(GameObject finalWaypointGameObject)
    {
        finalWaypoint = finalWaypointGameObject;
    }

    private void MoveToPosition(Vector2 position)
    {
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), position, speed * Time.deltaTime);
    }

    // Code from Unity Forum
    private void RotateTowards(Vector2 target)
    {
        var offset = 270f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}
