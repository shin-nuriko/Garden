using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] float damagePoints = 50f;
    // Start is called before the first frame update
    public float GetDamage()
    {
        return damagePoints;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}