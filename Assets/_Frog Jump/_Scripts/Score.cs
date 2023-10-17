using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    
    private static int _score = 0;
    public int finalScore;
    [SerializeField]private TMP_Text[] scoreText;

    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        AddScore(0);

    }

    private void Update()
    {
        if (GameManager.Instance.gameEnd)
        {
            finalScore = _score;
        }
    }

    public void AddScore(int point)
    {
        _score += point;
        ScoreText();
    }

    public void ReduceScore()
    {
        if (_score < 1) return;
        _score--;
        ScoreText();
    }

    public void ResetScore()
    {
        _score = 0;
        ScoreText();
    }

    private void ScoreText()
    {
        foreach (var score in scoreText)
        {
            score.text = "Score: " + _score;
        }
    }
}
