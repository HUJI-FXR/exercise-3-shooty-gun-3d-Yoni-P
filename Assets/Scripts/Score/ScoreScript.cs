using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float comboTimer;
    [SerializeField] private int comboBonus;
    
    public event Action<int> ScoreChanged;
    
    private int _totalScore = 0;

    private void Update()
    {
        scoreText.text = "Score: " + _totalScore;
        comboTimer += Time.deltaTime;
    }

    public void AddScore ()
    {
        _totalScore += 1 + (int)(comboBonus / comboTimer);
        comboTimer = 0f;
        ScoreChanged?.Invoke(_totalScore);
    }
}
