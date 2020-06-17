using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScore;

    [SerializeField] TextMeshProUGUI endScore;
    private void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 00000).ToString("00000");
        endScore.text = PlayerPrefs.GetInt("CurrentScore", 00000).ToString("00000");

    }


    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
