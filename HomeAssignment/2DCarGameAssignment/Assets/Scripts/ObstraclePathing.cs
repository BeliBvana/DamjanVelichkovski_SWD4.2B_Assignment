using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstraclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 2f;
    int waypointIndex = 0;
    //waypointIndex shows in which waypoint the obstracle currently is


    // Start is called before the first frame update
    void Start()
    {
        // setting the starting position of the obstracle to the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            //save the current waypoint in targetPosition
            //targetPosition: where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            //to make sure z position is 0	
            targetPosition.z = 0f;

            var movementThisFrame = moveSpeed * Time.deltaTime;
            //move from the current position, to the target position, the maximum distance one can move
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //if we reached the target waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //if obstracle moved to all waypoints
        else
        {
            Destroy(gameObject);
        }

    }

}
