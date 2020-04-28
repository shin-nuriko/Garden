using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] float dieAnimationDuration = 0.6f;
    [SerializeField] float attackAnimationDuration = 0.6f;

    bool isAttacking = false;
    Attacker attacker;
    private void Start()
    {
        attacker = GetComponent<Attacker>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Damager damageDealer = other.gameObject.GetComponent<Damager>();
        if (!damageDealer) { return; }

        var otherDamage = damageDealer.GetDamage();     
        if (attacker.TakeDamage(otherDamage) <= 0)
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
        attacker.SetAttackOn();
        gameObject.GetComponent<Animator>().Play("Attack");
        transform.Translate(Vector2.left * 0.1f);
        yield return new WaitForSeconds(attackAnimationDuration);
        gameObject.GetComponent<Animator>().Play("Walk");
        attacker.SetAttackOff();
    }
    private void Die()
    {
        attacker.SetMovementSpeed(0);
        gameObject.GetComponent<Animator>().Play("Die");
        Destroy(gameObject, dieAnimationDuration);
    }
}
