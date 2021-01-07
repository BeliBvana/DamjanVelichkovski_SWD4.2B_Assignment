using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    //the enemy
    [SerializeField] GameObject enemyPrefab;
    //the path on which to go
    [SerializeField] GameObject pathPrefab;
    //time between each spawn
    [SerializeField] float timeBetweenSpawns = 0.5f;
    //include this random time difference between spawns
    [SerializeField] float spawnRandomFactor = 0.3f;
    //number of enemies in the wave
    [SerializeField] int numberOfEnemies = 5;
    //enemy movement speed
    [SerializeField] float enemyMoveSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
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
