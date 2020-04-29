using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] float walkAnimationSpeed = 0.3f;
    [SerializeField] float dieAnimationDuration = 0.6f;
    [SerializeField] float attackAnimationDuration = 0.5f;
    [SerializeField] float attackAnimationSpeed = 0f;
    [SerializeField] float jumpAnimationDuration = 0.75f;
    [SerializeField] float jumpAnimationSpeed = 2.5f;

    Attacker attacker;
    GameObject fox;
    private void Start()
    {
        attacker = GetComponent<Attacker>();
        attacker.SetMovementSpeed(walkAnimationSpeed);
        fox = gameObject.transform.GetChild(0).transform.gameObject;//all our animation is on the first child object
        Debug.Log(fox);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        TakeAction(other.gameObject);
    }
    private void TakeAction(GameObject Target)
    {
        Damager targetDamageDealer = Target.GetComponent<Damager>();
        if (!targetDamageDealer) { return; }
        //jump over stone
        if (Target.GetComponent<Stone>())
        {
            Debug.Log("Fox vs Stone");
            StartCoroutine(Jump());
        }
        else
        {
            var otherDamage = targetDamageDealer.GetDamage();
            if (attacker.TakeDamage(otherDamage) <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(Attack());
            }
        }
    }
    private IEnumerator Attack()
    {
        attacker.SetAttackOn();
        attacker.SetMovementSpeed(attackAnimationSpeed);
        fox.GetComponent<Animator>().Play("Attack");
        yield return new WaitForSeconds(attackAnimationDuration);
        attacker.SetMovementSpeed(walkAnimationSpeed);
        fox.GetComponent<Animator>().Play("Walk");
        attacker.SetAttackOff();
    }
    private IEnumerator Jump()
    {
        attacker.SetMovementSpeed(jumpAnimationSpeed);
        fox.GetComponent<Animator>().Play("Jump");
        yield return new WaitForSeconds(jumpAnimationDuration);
        attacker.SetMovementSpeed(walkAnimationSpeed);
        fox.GetComponent<Animator>().Play("Walk");
    }
    private void Die()
    {
        attacker.SetMovementSpeed(0);
        fox.GetComponent<Animator>().Play("Die");
        Destroy(gameObject, dieAnimationDuration);
    }
}
