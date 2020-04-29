using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 60f;
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
    }

    public bool IsGameTimerFinished()
    {
        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);
        return timeFinished;
    }
}
