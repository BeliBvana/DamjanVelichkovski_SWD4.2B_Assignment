using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] int scoreValue = 5;
    [SerializeField] AudioClip pointsgained;
    [SerializeField] [Range(0, 1)] float pointsgainedvolume = 0.75f;    

    public void OnTriggerEnter2D(Collider2D otherObject)
    {
        if(otherObject.gameObject.tag == "Obstracle")
        {
            Destroy(otherObject.gameObject); // Destroys game object
            AudioSource.PlayClipAtPoint(pointsgained, Camera.main.transform.position, pointsgainedvolume);
            //Debug.Log("Hello"); // I was checking this as I had issues with the game tag
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
        else
        {
            Destroy(otherObject.gameObject);
        }
    }
}