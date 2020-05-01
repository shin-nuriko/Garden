using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] float gold = 100;
    Text goldText;
    float gameDifficulty = 1f;

    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<Text>();
        if (FindObjectOfType<PlayerPrefsController>())
        {
            gameDifficulty = FindObjectOfType<PlayerPrefsController>().GetMasterDifficulty();
            Debug.Log("Game Difficulty : " + gameDifficulty);
            gold = gold / gameDifficulty;
        }
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        goldText.text = gold.ToString();
    }

    public void AddGolds(int amount)
    {
        gold += amount;
        UpdateDisplay();
    }

    public bool SpendGolds(int amount)
    {
        if (gold >= amount)
        {
            gold -= amount;
            UpdateDisplay();
            return true;
        }
        return false;
    }
   
}
