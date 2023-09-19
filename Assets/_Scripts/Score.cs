using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreText ;
    private void Awake()
    {
        scoreText.text = "Score: " + GameManager.AddScore(0);
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
        scoreText.text = "Score: " + GameManager.AddScore(1);
        
    }
}
