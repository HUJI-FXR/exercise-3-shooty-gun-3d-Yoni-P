using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private ScoreScript scoreScript;
    [SerializeField] private TextMeshProUGUI gameOverMessage;
    
    private int _highScore = 0;

    public int HighScore => _highScore; 

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
        }
        OnScoreChanged(_highScore);
        scoreScript.ScoreChanged += OnScoreChanged;
        LifeTotalScript.PlayerDied += OnPlayerDied;
    }

    private void OnScoreChanged(int score)
    {
        if (score > _highScore)
        {
            _highScore = score;
        }
        highScoreText.text = "High Score: " + _highScore;

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
            OnAllEnemiesDead();
    }

    private void OnAllEnemiesDead()
    {
        UpdateHighScore();
        ShowGameOverMessage("You Win!");
    }

    private void OnPlayerDied()
    {
        UpdateHighScore();
        ShowGameOverMessage("You Lose!");
    }

    private void ShowGameOverMessage(String message)
    {
        gameOverMessage.gameObject.SetActive(true);
        gameOverMessage.text = message;
    }

    private void UpdateHighScore()
    {
        int curHighScore = PlayerPrefs.HasKey("HighScore") ? PlayerPrefs.GetInt("HighScore") : 0;

        if (_highScore >= curHighScore)
        {
            PlayerPrefs.SetInt("HighScore", _highScore);
        }
    }
}
