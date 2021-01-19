using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin, xMax, yMin, yMax;
    [SerializeField] float padding = 10f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 50;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration;


    [SerializeField] AudioClip healthreduce;

    [SerializeField] [Range(0, 1)] float healthreducevolume = 0.75f;

    GameSession gameSession;
    int total = 100;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public int GetHealth()
    {
        return health;
    }


    private void Move()
    {
        //var is used as a generic variable. VS allows us to use var and it will set its type depending on the value it will have
        // deltaX will be updated with the input that will happen on the x-axis, left and right
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        //the x-position will be updated according to the newXPos - whether left or right. Y position will be the same
        transform.position = new Vector2(newXPos, transform.position.y);
    }

    private void SetUpMoveBoundaries()
    {
        //setup the boundaries of the movement according to the camera
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

    }

    //reduces health whenever enemy collides with a gameObject which has DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //saving all the information of the DamageDealer objectLaser in dmg
        DamageDealer damage = otherObject.gameObject.GetComponent<DamageDealer>();
        Explosion explosion = otherObject.gameObject.GetComponent<Explosion>();
        // if the object does not have a damageDealer class end the method
        if (otherObject.gameObject.tag == "Obstracle")//if dmg does not exist
        {
            ProcessHit(damage);
            explosion.ObstracleExplosion();

            return;
        }

        ProcessHit(damage);
    }

    private void ProcessHit(DamageDealer damage)
    {
        health -= damage.GetDamage();
        AudioSource.PlayClipAtPoint(healthreduce, Camera.main.transform.position, healthreducevolume);
       // Debug.Log(health);
        damage.Hit();
        if ((health <= 0) && (gameSession.GetScore() < total))
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        //create an explosion particle
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after 1 sec
        Destroy(explosion, 1f);
        //find object of type Level in Hierarchy and run its method LoadGameOver()
        FindObjectOfType<Level>().LoadGameOver();

    }

}