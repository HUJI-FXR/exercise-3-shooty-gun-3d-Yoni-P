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
    [SerializeField] private MonsterSpawner monsterSpawner;
    
    private int _highScore = 0;
    private int _numMonsters;

    public int HighScore => _highScore; 

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
        }
        highScoreText.text = "High Score: " + _highScore;
        _numMonsters = monsterSpawner.NumMonstersSpawned;
    }

    private void OnEnable()
    {
        scoreScript.ScoreChanged += OnScoreChanged;
        LifeTotalScript.PlayerDied += OnPlayerDied;
        EnemiesTracker.AllEnemiesDead += OnAllEnemiesDead;
    }

    private void OnDisable()
    {
        scoreScript.ScoreChanged -= OnScoreChanged;
        LifeTotalScript.PlayerDied -= OnPlayerDied;
        EnemiesTracker.AllEnemiesDead -= OnAllEnemiesDead;
    }

    private void OnScoreChanged(int score)
    {
        if (score > _highScore)
        {
            _highScore = score;
        }
        highScoreText.text = "High Score: " + _highScore;
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
