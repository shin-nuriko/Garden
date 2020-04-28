using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damagePoints = 50f;

    public float GetDamage()
    {
        return damagePoints;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}