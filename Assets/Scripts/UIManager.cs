using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {

        UpdateScore(0);
    }

   public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("00000");
    }
}
