using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(149,149,149,255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<SpawnArea>().SetSelectedDefender(defenderPrefab);

    }
}
