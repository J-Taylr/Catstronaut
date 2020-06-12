using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnRate = 10f;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject spawnPoint;
    [Header("Position")]
    public bool Top;
    public bool Bottom;
    public bool Left;
    public bool Right;

    int randomX = Random.Range(-30, 30);
    int randomZ = Random.Range(-21, 21);

    private void Start()
    {
        StartCoroutine(SpawnEnemyTop());
        
    }

   

    IEnumerator SpawnEnemyTop()
    {
        if(Top == true)
        {
            Vector3 newxSpawn = spawnPoint.transform.position + new Vector3(Random.Range(-30, 30), 0, 25);
            print("spawning");
            GameObject enemy = Instantiate(enemyPrefab, newxSpawn, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(spawnRate);
        }
        if (Bottom == true)
        {
            Vector3 newxSpawn = spawnPoint.transform.position + new Vector3(Random.Range(-30, 30), 0, -20);
            print("spawning");
            GameObject enemy = Instantiate(enemyPrefab, newxSpawn, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(spawnRate);
        }
        if (Left == true)
        {
            Vector3 newxSpawn = spawnPoint.transform.position + new Vector3(35, 0, Random.Range(25, -20));
            print("spawning");
            GameObject enemy = Instantiate(enemyPrefab, newxSpawn, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(spawnRate);
        }
        if (Right == true)
        {
            Vector3 newxSpawn = spawnPoint.transform.position + new Vector3(-30, 0, Random.Range(25, -20));
            print("spawning");
            GameObject enemy = Instantiate(enemyPrefab, newxSpawn, Quaternion.Euler(90, 0, 0));
            yield return new WaitForSeconds(spawnRate);
        }              
       
    }
    

}
