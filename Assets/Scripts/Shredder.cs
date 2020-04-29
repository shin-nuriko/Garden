using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    [SerializeField] bool isBehindHomeField = false;

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;

        if (isBehindHomeField)
        {
            //take damage from attackers with damagers only
            if (other.GetComponent<Attacker>() && other.GetComponent<Damager>())
            {
                float damage = other.GetComponent<Damager>().GetDamage();
                playerHealth.TakeDamage( Mathf.RoundToInt(damage) ); 
            }
        }
        Destroy(other);

    }
}
