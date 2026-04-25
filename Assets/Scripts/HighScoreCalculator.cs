using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class HighScoreCalculator : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    List<int> highScores;
    ScoreManager scoreManager;
    
    [SerializeField]    private TMP_Text highScoreText;
    [SerializeField]    private TMP_Text highScoreText2;
    void Start()
    {   
        highScores = new List<int>();
        highScores.Add(0);
        highScores.Add(0);
        scoreManager = new ScoreManager();
    }

    // Update is called once per frame
    void Update()
    {
        HighScoreUpdate();
        
        highScoreText.text = "High Score: " + highScores[0];
        highScoreText2.text = "High Score: " + highScores[1];
    }

    void HighScoreUpdate()
    {
        highScores.Add(scoreManager.GetScore());
        highScores.Sort();
    }
}
