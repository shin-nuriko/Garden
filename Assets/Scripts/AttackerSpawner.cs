using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] List<Attacker> attackersPrefab;

    bool spawn = true;
    int minIndex = 0;
    int maxIndex;
    Attacker attackerPrefab;
    void Start()
    {        
        maxIndex = attackersPrefab.Count;
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
        attackerPrefab = attackersPrefab[UnityEngine.Random.Range(minIndex, maxIndex)];
        Attacker newAttacker = Instantiate(
            attackerPrefab,
            transform.position,
            transform.rotation
            ) as Attacker;
        newAttacker.transform.parent = transform; //spawns as child of attackerspawner gameobject
    }

}
