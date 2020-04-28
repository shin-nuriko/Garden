using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker attackerPrefab;

    bool spawn = true;
    void Start()
    {
        StartCoroutine(StartSpawning());
    }
     IEnumerator StartSpawning()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {        
        Attacker newAttacker = Instantiate(
            attackerPrefab,
            transform.position,
            transform.rotation
            ) as Attacker;
        newAttacker.transform.parent = transform; //spawns as child of attackerspawner gameobject
    }

}
