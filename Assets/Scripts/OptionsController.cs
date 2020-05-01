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
}
