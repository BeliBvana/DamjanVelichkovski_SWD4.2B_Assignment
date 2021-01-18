using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{

    [SerializeField] AudioClip pointsgained;

    [SerializeField] [Range(0, 1)] float pointsgainedvolume = 0.75f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            //destroy game object
            Destroy(collision.gameObject);

            AudioSource.PlayClipAtPoint(pointsgained, Camera.main.transform.position, pointsgainedvolume);


        }
        else
        {
            Destroy(collision.gameObject);
        }
        
    }

}