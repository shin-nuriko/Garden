using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float dieAnimationDuration = 0.6f;
    float currentSpeed = 1f;
    
    void Update()
    {
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Damager damageDealer = other.gameObject.GetComponent<Damager>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        if (health <= 0 ) { Die(); }
        damageDealer.Hit();

        Debug.Log("Attacker Health: " + health);
    }

    private void Die()
    {
        currentSpeed = 0;        
        gameObject.GetComponent<Animator>().Play("Die");
        Destroy(gameObject, dieAnimationDuration);
    }

}
