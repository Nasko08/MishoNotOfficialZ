using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int waypoint = 0;

    void Start()
    {
        target = Waypoints.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    void GetNextWaypoint()
    {
        if (waypoint < Waypoints.points.Length - 1)
        {
            waypoint++;
            target = Waypoints.points[waypoint];
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
