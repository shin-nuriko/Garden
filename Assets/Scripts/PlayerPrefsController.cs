using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume";
    const string DIFFICULTY_KEY = "difficulty";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const float DEFAULT_VOLUME = 0.5f;

    const float MIN_DIFFICULTY = 0.1f;
    const float MAX_DIFFICULTY = 2f;
    const float DEFAULT_DIFFICULTY = 1f;

    public void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Volume is out of range.");
        }
    }

    public float GetMasterVolume()
    {
        float prefVolume = PlayerPrefs.GetFloat(VOLUME_KEY);
        if (prefVolume >= 0)
            return prefVolume;
        else
            return DEFAULT_VOLUME;  
    }

    public float GetDefaultVolume()
    {
        return DEFAULT_VOLUME;
    }

    public void SetMasterDifficulty(float difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty is out of range.");
        }
    }

    public float GetMasterDifficulty()
    {
        float prefDifficulty = PlayerPrefs.GetFloat(DIFFICULTY_KEY);
        if (prefDifficulty > 0)
            return prefDifficulty;
        else
            return DEFAULT_DIFFICULTY;
    }

    public float GetDefaultDifficulty()
    {
        return DEFAULT_DIFFICULTY;
    }
}
