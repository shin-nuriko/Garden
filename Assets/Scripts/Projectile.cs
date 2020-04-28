using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float currentSpeed = 2f;
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }
    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // trigger some sort of projectile explosion animation here
    }
}
