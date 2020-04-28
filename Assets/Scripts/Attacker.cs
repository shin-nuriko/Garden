using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float dieAnimationDuration = 0.6f;
    [SerializeField] float attackAnimationDuration = 0.6f;
    float currentSpeed = 1f;

    bool isAttacking = false;
    void Update()
    {
        if (!isAttacking) //don't move during attack
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
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
        if (health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;
        gameObject.GetComponent<Animator>().Play("Attack");        
        transform.Translate(Vector2.left * 0.1f);
        yield return new WaitForSeconds(attackAnimationDuration);
        gameObject.GetComponent<Animator>().Play("Walk");
        isAttacking = false;
    }
    private void Die()
    {
        currentSpeed = 0;        
        gameObject.GetComponent<Animator>().Play("Die");
        Destroy(gameObject, dieAnimationDuration);
    }

}
