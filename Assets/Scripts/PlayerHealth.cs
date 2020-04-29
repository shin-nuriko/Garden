using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    Text healthText;
    GameOver gameOver;
    void Start()
    {
        gameOver = FindObjectOfType<GameOver>();
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
            health = 0;
            UpdateDisplay();
            StartCoroutine(GameOver());
        }
    }
    IEnumerator GameOver()
    {
        gameOver.DisplayGameOver();
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<LevelLoader>().LoadGameEnd();
    }
}
