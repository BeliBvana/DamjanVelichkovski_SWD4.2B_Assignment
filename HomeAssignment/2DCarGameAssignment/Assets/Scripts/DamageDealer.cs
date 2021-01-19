using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    //the damage received
    public int GetDamage()
    {
        return damage;
    }

    //destroys the object
    public void Hit()
    {
        Destroy(gameObject);
    }
}