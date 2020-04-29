using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    GameTimer gameTimer;
    AttackerSpawner[] spawners;
    bool spawnStopped;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        spawners = FindObjectsOfType<AttackerSpawner>();
        spawnStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        int attackersLeft = CountAttackers();
        if (gameTimer.IsGameTimerFinished() && attackersLeft <= 0 )
        {
            Debug.Log("Game timer is finished AND no more attackers left!");
        }
        if (gameTimer.IsGameTimerFinished() && spawnStopped == false)
        {
            Debug.Log("Game timer is finished!");
            StopAllAttackerSpawners();
        }
    }

    private int CountAttackers()
    {
        int attackerCount = 0;
        foreach (AttackerSpawner spawner in spawners)
        {
            attackerCount += spawner.gameObject.transform.childCount;
        }
        return attackerCount;
    }

    private void StopAllAttackerSpawners()
    {
        Debug.Log("Stop all attacker spawners!");
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
        spawnStopped = true;
    }

}
