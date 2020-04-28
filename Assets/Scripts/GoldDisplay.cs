using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] int gold = 100;
    Text goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText = GetComponent<Text>();
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
