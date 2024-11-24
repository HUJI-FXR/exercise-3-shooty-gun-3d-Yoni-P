using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTotalScript : MonoBehaviour
{
    [SerializeField] private float initialLifeTotal = 100f;
    public static event Action PlayerDied;

    public float LifeTotal => _lifeTotal;

    private float _lifeTotal;

    private ScoreScript _scoreScript;
    private HighScoreScript _highScoreScript;
    
    private void Start()
    {
        _lifeTotal = initialLifeTotal;
        _scoreScript = FindObjectOfType<ScoreScript>();
        _highScoreScript = FindObjectOfType<HighScoreScript>();
    }

    public void ReduceLife(float amount)
    {
        _lifeTotal -= amount;

        if (_lifeTotal < 0)
        {
            if (gameObject.CompareTag("Enemy"))
                _scoreScript.AddScore();
            else if (gameObject.CompareTag("Player"))
            {
                PlayerDied.Invoke();
            }
            
            Destroy(gameObject);
        }
    }

    public float GetLifeRatio()
    {
        return _lifeTotal / initialLifeTotal;
    }
}
