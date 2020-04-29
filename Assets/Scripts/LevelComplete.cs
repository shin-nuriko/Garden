using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    GameObject levelCompleteText;
    void Start()
    {
        levelCompleteText = transform.GetChild(0).gameObject;
        levelCompleteText.SetActive(false);
    }

    public void DisplayLevelComplete()
    {
        levelCompleteText.SetActive(true);
    }
}
