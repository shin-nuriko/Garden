using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    GameTimer gameTimer;
    AttackerSpawner[] spawners;
    LevelComplete levelComplete;
    PlayerHealth player;
    GameOverText gameOver;
    bool spawnStopped;
    float displayPause = 7f;

    void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>();
        spawners = FindObjectsOfType<AttackerSpawner>();
        gameOver = FindObjectOfType<GameOverText>();
        levelComplete = FindObjectOfType<LevelComplete>();
        player = FindObjectOfType<PlayerHealth>();
        spawnStopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.IsPlayerAlive() == false)
        {
            StartCoroutine(GameOver());
            return;
        }

        int attackersLeft = CountAttackers();
        if (gameTimer.IsGameTimerFinished() && attackersLeft <= 0 )
        {
            StartCoroutine(LoadNextLevel());
            return;
        }

        if (gameTimer.IsGameTimerFinished() && spawnStopped == false)
        {
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
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
        spawnStopped = true;
    }

    IEnumerator GameOver()
    {       
        gameOver.DisplayGameOver();
        yield return new WaitForSeconds(displayPause);
        Destroy(gameOver);
        FindObjectOfType<LevelLoader>().LoadGameEnd();
    }
    IEnumerator LoadNextLevel()
    {
        levelComplete.DisplayLevelComplete();
        yield return new WaitForSeconds(displayPause);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

}
