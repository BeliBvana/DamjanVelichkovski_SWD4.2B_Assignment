using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstracleSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs; 
    [SerializeField] bool looping = false;
    readonly int startingWave = 0; // Always starting from here

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves()); // Start the coroutine that spawns all enemies in our currentWave
        }
        while (looping); // When coroutine SpawnAllWaves finishes check if looping == true
    }

    // When calling this Corotuine, we need to specify which WaveConfig we want to spawn
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            //spawn the enemy from 
            //at the position specified by the waveConfig waypoints
            var newEnemy = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            //the wave will be selected from here and the enemy applied to it
            newEnemy.GetComponent<ObstraclePathing>().SetWaveConfig(waveConfig);

            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        // This will loop from startingWave until we reach the last within our List
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            // The coroutine will wait for all enemies in Wave to spawn
            // Before yielding and going to the next loop
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }
}