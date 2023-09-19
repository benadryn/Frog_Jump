using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText ;
    private int _score;
    private void Start()
    {
        _score = GameManager.Score;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddScore();
            Destroy(gameObject);
        }
    }

    void AddScore()
    {
        _score += 1;
        scoreText.text += _score;
        
    }
}
