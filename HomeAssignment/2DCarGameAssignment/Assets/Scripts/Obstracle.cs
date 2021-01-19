using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstracle : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 2f;
    [SerializeField] GameObject obstacleLaserPrefab;
    [SerializeField] float obstacleLaserSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {        
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots); // Generates a random number
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    // Count down shotCounter to 0 and shoot
    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime; // Every frame reduce the amount of time of shotCounter

        if (shotCounter <= 0f)
        {
            ObstacleFire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots); // Reset shotCounter after every fire
        }
    }

    // Spawns an obstacle Laser from the Obstacle's position
    private void ObstacleFire()
    {
        GameObject enemyLaser = Instantiate(obstacleLaserPrefab, transform.position, Quaternion.identity);

        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleLaserSpeed); // Obstacle laser shoots downwards, hence -obstacleLaserSpeed
    }
}