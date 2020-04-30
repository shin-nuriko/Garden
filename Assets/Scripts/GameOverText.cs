using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    [SerializeField] AudioClip GameOverSFX;
    [Range(0f, 1f)] [SerializeField] float onGameOverSFXVolume = 0.5f;

    GameObject gameOverText;
    bool wasTriggeredOnce = false;
    void Start()
    {
        gameOverText = transform.GetChild(0).gameObject;
        gameOverText.SetActive(false);
    }

    public void DisplayGameOver()
    {
        gameOverText.SetActive(true);
        //make sure we only play sound once
        if (!wasTriggeredOnce)
        {
            PlayGameOverSound();
        }
    }

    private void PlayGameOverSound()
    {
        AudioSource.PlayClipAtPoint(
                GameOverSFX,
                Camera.main.transform.position,
                onGameOverSFXVolume);
        wasTriggeredOnce = true;
    }
}
