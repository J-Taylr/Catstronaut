﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;

[RequireComponent(typeof(UIManager))]

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
    [SerializeField] GameObject gameScreen;
    [SerializeField] GameObject overScreen;

    int playerScore;
    int playerHealth = 4;
    bool scoreBeaten = false;
    
   [SerializeField] float scoreCap = 500;

    FMOD.Studio.EventInstance music;
    FMOD.Studio.EventInstance bullet;
    FMOD.Studio.EventInstance explode;
    HighScore highScore;
    

    private void Start()
    {
        music = FMODUnity.RuntimeManager.CreateInstance("event:/Music");
        music.setParameterByName("Lives", 0);
        
        music.start();
        spawnRate = 0.3f;


        overScreen.SetActive(false);
        gameScreen.SetActive(true);
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
        SetMusic();
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
        PlayerPrefs.SetInt("CurrentScore", playerScore);

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
        cameraAnim.SetTrigger("Damage");
        SetLives();
        catAnim.Play("SadCat");
        commsCat.SetTrigger("Sad");
        turretAnim.Play("HeartBreak");
        
        if (playerHealth <= 0)
        {
            gameScreen.SetActive(false);
            overScreen.SetActive(true);


           // stop gameplay and music
           //make game over ui appear
          
        }

    }

    public void SetMusic()
    {
        if (playerHealth == 3)
        {
            print("section switch");
            music.setParameterByName("Lives", 1);
        }
        if (playerHealth == 2)
        {
            music.setParameterByName("Lives", 2); 
        }
        if (playerHealth == 1)
        {
            music.setParameterByName("Lives", 3);
        }
        if (playerHealth <= 0)
        {
            music.release();
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
        if (playerHealth < 1)
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

    public void PlayBullet()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Lasermeow");
    }
    public void PlayExplosion()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Explosion");
    }

    public void StopMusic()
    {
        music.release();
    }
   
}
