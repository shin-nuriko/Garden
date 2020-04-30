using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    [SerializeField] AudioClip LevelOkSFX;
    [Range(0f, 1f)] [SerializeField] float onLevelOkSFXVolume = 0.5f;

    GameObject levelCompleteText;
    bool wasTriggeredOnce = false;
    void Start()
    {
        levelCompleteText = transform.GetChild(0).gameObject;
        levelCompleteText.SetActive(false);
    }

    public void DisplayLevelComplete()
    {
        levelCompleteText.SetActive(true);
        //make sure we only play sound once
        if (!wasTriggeredOnce)
        {
            PlayLevelOkSound();
        }
    }
    private void PlayLevelOkSound()
    {
        AudioSource.PlayClipAtPoint(
                LevelOkSFX,
                Camera.main.transform.position,
                onLevelOkSFXVolume);
        wasTriggeredOnce = true;
    }

}
