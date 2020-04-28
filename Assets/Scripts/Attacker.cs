using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float health = 100f;
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

    public void SetAttackOn()
    {
        isAttacking = true;
    }

    public void SetAttackOff()
    {
        isAttacking = false;
    }

    public float TakeDamage(float damage)
    {
        health -= damage;
        return health;
    }

}
