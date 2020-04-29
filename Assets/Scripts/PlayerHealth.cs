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
        if (health >= damage)
        {
            health -= damage;
            UpdateDisplay();
        }
        else
        {           
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelLoader>().LoadGameEnd();
    }
}
