﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] float spawnRate = 10f;
    [SerializeField] GameObject enemyPrefab;    
    [SerializeField] GameObject spawnPoint;
    [Header("Position")]
    public bool TB; //top bottom (! = left right)


   

    public EnemyManager SpawnEnemy()
    {
        Vector3 newxSpawn;
        if (TB)
        {
           newxSpawn = spawnPoint.transform.position + new Vector3(Random.Range(-30, 30), 0, 0);
           
        }
        else
        {
            newxSpawn = spawnPoint.transform.position + new Vector3(0, Random.Range(25, -20), 0);
        }
            GameObject enemy = Instantiate(enemyPrefab, newxSpawn, Quaternion.Euler(0, 0, 0));
        return enemy.GetComponent<EnemyManager>();
    }    
}
