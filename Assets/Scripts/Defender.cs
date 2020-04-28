using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int goldCost = 50;
    [SerializeField] float health = 100f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Defender Collision detected");
        Damager damageDealer = other.gameObject.GetComponent<Damager>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        //damageDealer.Hit();
        if (health <= 0 ) { Die();  }

        Debug.Log("Defender Health: " + health);
    }

    public void AddGold(int amount)
    {
        FindObjectOfType<GoldDisplay>().AddGolds(amount);
    }

    public int GetGoldCost()
    {
        return goldCost;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
