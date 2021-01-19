using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    public int GetDamage()
    {
        return damage; // Gets the damage
    }

    public void Hit()
    {
        Destroy(gameObject); // Destroys object
    }
}