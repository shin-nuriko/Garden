using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] float spawnZPosition = -2f;
    GoldDisplay goldDisplay;
    Defender defender;
    int defendercost;

    private void Start()
    {
        goldDisplay = FindObjectOfType<GoldDisplay>();    
    }
    private void OnMouseDown()
    {
        if (goldDisplay.SpendGolds(defendercost))
        {
            SpawnDefender(GetSquareClicked());
        }        
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
        defendercost = defender.GetGoldCost();
    }
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        //round of the positions
        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y);
        return worldPos;
    }
    private void SpawnDefender(Vector2 position)
    {
        var spawnPos = new Vector3(position.x, position.y, spawnZPosition);
        Defender newDefender = Instantiate(
                defender,
                spawnPos,
                Quaternion.identity
            ) as Defender;
    }
}
