using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] Animator scoreAnim;

    


    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 00000).ToString("00000");

        UpdateScore(0);
    }

   public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("00000");

    }

    public void UpdateHighScore(int score)
    {
        highScore.text = score.ToString("00000");

    }

    public void HighScoreAnim()
    {
        scoreAnim.SetTrigger("NewHighScore");
    }

}


