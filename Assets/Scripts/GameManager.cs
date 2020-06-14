using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[RequireComponent(typeof(UIManager))]
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [HideInInspector] public UIManager UI;
    [Header("Spawners")]
    public List<EnemySpawner> enemySpawner = new List<EnemySpawner>();
    public List<GameObject> meteorsSpawned = new List<GameObject>();
    [Tooltip("meteor per sec")] public float spawnRate;
    public float spawntimer;

    [Header("Animators")]
    [SerializeField] Animator catAnim;
    [SerializeField] Animator turretAnim;

    [Header("UI")]
    [SerializeField] Image lifeOne;
    [SerializeField] Image lifeTwo;
    [SerializeField] Image lifeThree;
    [SerializeField] Image lifeFour;

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
        SetLives();
        catAnim.Play("SadCat");
        turretAnim.Play("HeartBreak");
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }

    }

    public void SetLives()
    {
        if (playerHealth == 4)
        {
            lifeFour.enabled = true;
            lifeThree.enabled = true;
            lifeTwo.enabled = true;
            lifeOne.enabled = true;
        }
        if (playerHealth == 3)
        {
            lifeFour.enabled = false;
        }
        if (playerHealth == 2)
        {
            
            lifeThree.enabled = false;
        }
        if (playerHealth == 1)
        {
            lifeTwo.enabled = false;
        }
    }
    
}
