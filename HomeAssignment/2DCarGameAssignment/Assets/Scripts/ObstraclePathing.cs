using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstraclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] WaveConfig waveConfig;
    int waypointIndex = 0; // WaypointIndex shows in which waypoint is the obstracle currently

    // Start is called before the first frame update
    void Start() // Setting the starting position of the obstracle to the first waypoint
    {
        waypoints = waveConfig.GetWaypoints(); 
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
            // Save the current waypoint in targetPosition
            // TargetPosition: where we want to go
            var targetPosition = waypoints[waypointIndex].transform.position;

            // To make sure z position is 0	
            targetPosition.z = 0f;

            var movementThisFrame = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            // Move from the current position, to the target position, the maximum distance one can move
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            // If we reached the target waypoint
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
    }

    // Setting up a WaveConfig
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}