using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    float currentVolume = 0;

    //first state that comes before start
    private void Awake()
    {
        int musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        //set volume
        float musicVolume = FindObjectOfType<PlayerPrefsController>().GetMasterVolume();
        if (musicVolume != currentVolume)
        {
            GetComponent<AudioSource>().volume = musicVolume;
            currentVolume = musicVolume;
        }
    }
}