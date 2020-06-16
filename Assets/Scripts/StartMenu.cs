using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TextMeshProUGUI highScore;

    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString("00000"); 
    }


    public void StartGame()
    {
        
        SceneManager.LoadScene(1);
       
    }

   
}
