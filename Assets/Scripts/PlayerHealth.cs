using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;

    void Start()
    {         
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }
    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)//prevent displaying negative health value
        {
            health = 0;
        }
        UpdateDisplay();
    }

    public bool IsPlayerAlive()
    {
        if (health <= 0) { return false; }
        else { return true; }
    }

}
