using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    GameObject volumeOption;
    GameObject difficultyOption;
    PlayerPrefsController playerPrefController;
    // Start is called before the first frame update
    void Start()
    {
        volumeOption = transform.Find("Volume/VolumeSlider").gameObject;
        difficultyOption = transform.Find("Difficulty/DifficultySlider").gameObject;
        playerPrefController = FindObjectOfType<PlayerPrefsController>();

        //populate with saved player prefs
        float volumePref = playerPrefController.GetMasterVolume();
        if (volumeOption.GetComponent<Slider>().value != volumePref)
        {
            volumeOption.GetComponent<Slider>().value = volumePref;
        }
        float difficultyPref = playerPrefController.GetMasterDifficulty();
        if (difficultyOption.GetComponent<Slider>().value != difficultyPref)
        {
            difficultyOption.GetComponent<Slider>().value = difficultyPref;
        }
    }

   public void UpdateVolume()
    {
        float volume = volumeOption.GetComponent<Slider>().value;
        playerPrefController.SetMasterVolume(volume);
    }
    public void UpdateDifficulty()
    {
        float difficulty = difficultyOption.GetComponent<Slider>().value;
        playerPrefController.SetMasterDifficulty(difficulty);
    }

    public void ResetToDefaults()
    {
        volumeOption.GetComponent<Slider>().value = playerPrefController.GetDefaultVolume();
        difficultyOption.GetComponent<Slider>().value = playerPrefController.GetDefaultDifficulty();
    }
}