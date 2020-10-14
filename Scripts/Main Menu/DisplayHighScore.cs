using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHighScore : MonoBehaviour
{
    private TextMeshProUGUI highScoreText;
    private float highScore; 
    
    void Start()
    {
        highScoreText = GetComponent<TextMeshProUGUI>();
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }
}
