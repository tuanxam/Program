using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private WayPoint _wayPoint;
    private int _waypointIndex;
    void Start()
    {
        _wayPoint = GameObject.FindGameObjectWithTag("WayPoint").GetComponent<WayPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _wayPoint.waypoints[_waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position,_wayPoint.waypoints[_waypointIndex].position) < 0.1f)
        {
            if (_waypointIndex < _wayPoint.waypoints.LongLength - 1)
            {
                _waypointIndex++;
            }
            else
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            Debug.Log("get hit");
        }
    }
    
}
