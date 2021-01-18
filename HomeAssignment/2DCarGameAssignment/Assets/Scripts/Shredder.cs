using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    [SerializeField] AudioClip healthReduce;

    [SerializeField] [Range(0, 1)] float healthReduceVolume = 0.75f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //destroy game object
            Destroy(collision.gameObject);

            AudioSource.PlayClipAtPoint(healthReduce, Camera.main.transform.position, healthReduceVolume);


        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }

}