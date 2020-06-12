using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(UIManager))]
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [HideInInspector] public UIManager UI;
    public List<EnemySpawner> enemySpawner = new List<EnemySpawner>();
    public List<GameObject> meteorsSpawned = new List<GameObject>();
    [Tooltip("meteor per sec")] public float spawnRate;
    public float spawntimer;
    int playerScore;
    int playerHealth = 4;





    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        UI = GetComponent<UIManager>();
    }


    private void Update()
    {
        spawntimer += Time.deltaTime * spawnRate;
        if (spawntimer >= 1)
        {
            spawntimer = 0; 
            
                GameObject newEnemy = enemySpawner[Random.Range(0, 4)].SpawnEnemy();
                meteorsSpawned.Add(newEnemy);
            
         }

    }



    public void SetScore(int addScore)
    {
        playerScore += addScore;
        UI.UpdateScore(playerScore);
    }

    public void SetHealth()
    {
        playerHealth--;

        if (playerHealth <= 0)
        {
            //death
        }

    }

}
