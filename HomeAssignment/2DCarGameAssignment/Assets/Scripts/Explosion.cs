using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;

    public void ObstracleExplosion()
    {
        //create an explosion particle
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
    }
}
