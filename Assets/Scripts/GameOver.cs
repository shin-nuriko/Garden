using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject gameOverText;
    void Start()
    {
        gameOverText = transform.GetChild(0).gameObject;
        gameOverText.SetActive(false);
    }

    public void DisplayGameOver()
    {
        gameOverText.SetActive(true);
    }
}
