using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    // The enemy
    [SerializeField] GameObject enemyPrefab;
    // The path on which to go
    [SerializeField] GameObject pathPrefab;
    // Time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    // Include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;
    // Number of enemies in the wave
    [SerializeField] int numberOfEnemies = 5;
    // Enemy movement speed
    [SerializeField] float enemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWayPoints = new List<Transform>(); // Each wave can have different waypoints

        foreach (Transform child in pathPrefab.transform) // Go into Path prefab and for each child, add it to the List waveWaypoints
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }
}