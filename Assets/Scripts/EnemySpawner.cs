using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnrate = 10f;
    [SerializeField] GameObject enemyPrefab;
    
    int randomX = Random.Range(-30, 30);
    int randomZ = Random.Range(-21, 21);

    private void Start()
    {
        StartCoroutine(SpawnEnemyTop());
        
    }

   

    IEnumerator SpawnEnemyTop()
    {
        while (true)
        {
            print("spawning");
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.Euler(90, 0, 0));
            enemy.transform.Translate(randomX, 0, 15);
            yield return new WaitForSeconds(5);
        }
       
    }

  
}
