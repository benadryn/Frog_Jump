using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Score : MonoBehaviour
{
    public static Score Instance;
    
    private static int _score = 0;
    [SerializeField]private TMP_Text scoreText;

    
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

    public void AddScore(int point)
    {
        _score += point;
        scoreText.text = "Score: " + _score;
    }
}
