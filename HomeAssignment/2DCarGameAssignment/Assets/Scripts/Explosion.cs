using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    public void ObstracleExplosion()
    {
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity); // Creates an explosion particle
        Destroy(explosion, 1f); // Destroys the explosion after 1 sec
    }
}
