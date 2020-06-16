using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(UIManager))]
[RequireComponent(typeof(AudioManager))]
public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    [HideInInspector] public UIManager UI;
    [HideInInspector] public AudioManager audioManager;
    [Header("Spawners")]
    public List<EnemySpawner> enemySpawner = new List<EnemySpawner>();
    public List<EnemyManager> meteorsSpawned = new List<EnemyManager>();
    [Tooltip("meteor per sec")] public float spawnRate;
    public float spawntimer;

    [Header("Animators")]
    [SerializeField] Animator catAnim;
    [SerializeField] Animator turretAnim;
    [SerializeField] Animator commsCat;
    [SerializeField] Animator cameraAnim;

    [Header("UI")]
    [SerializeField] Image lifeOne;
    [SerializeField] Image lifeTwo;
    [SerializeField] Image lifeThree;
    [SerializeField] Image lifeFour;

    int playerScore;
    int playerHealth = 4;
    bool scoreBeaten = false;
   [SerializeField] float scoreCap = 500;

    HighScore highScore;
    

    private void Start()
    {
        
        spawnRate = 0.3f;
    }



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
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        spawntimer += Time.deltaTime * spawnRate;
        if (spawntimer >= 1)
        {
            spawntimer = 0;

            EnemyManager newEnemy = enemySpawner[Random.Range(0, enemySpawner.Count)].SpawnEnemy();
            float speed = Random.Range(3, 14);
            newEnemy.MeteorSetup(speed);
            if (speed >= 7 ) { commsCat.SetTrigger("Danger"); }
            meteorsSpawned.Add(newEnemy);

        }

        IncreaseSpawnRate();
    }


    public void SetScore(int addScore)
    {
        playerScore += addScore;
        UI.UpdateScore(playerScore);
        Debug.Log(PlayerPrefs.GetInt("HighScore", 0));

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {

            PlayerPrefs.SetInt("HighScore", playerScore);            
            UI.UpdateHighScore(playerScore);
            if (!scoreBeaten)
            {
                UI.HighScoreAnim();
                scoreBeaten = true; 
            }
        }
    }

    public void SetHealth()
    {
        playerHealth--;
        audioManager.nextSection();
        cameraAnim.SetTrigger("Damage");
        SetLives();
        catAnim.Play("SadCat");
        commsCat.SetTrigger("Sad");
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
        if (playerHealth <= 0)
        {
            lifeOne.enabled = false;
        }
    }
    
    public void IncreaseSpawnRate()
    {
        if (playerScore >= scoreCap)
        {
            scoreCap += 500;
            spawnRate += 0.03f;
        }
        

        



    }



}
