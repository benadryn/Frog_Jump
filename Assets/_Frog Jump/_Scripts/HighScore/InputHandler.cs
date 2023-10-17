using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private HighScoreHandler highScoreHandler;
    [SerializeField] private GameObject inputField;
    private bool _scoreAdded;


    private void Update()
    {
        CheckIfNewHighScore();
    }

    private void CheckIfNewHighScore()
    {
        if (GameManager.Instance.didFinish && !_scoreAdded)
        {
            if (highScoreHandler.CheckForHighScore(new HighScoreElement("", Score.Instance.finalScore)))
            {
                inputField.SetActive(true);
            }
        }
    }

    public void AddNameToList()
    {
        highScoreHandler.AddHighScoreIfPossible(new HighScoreElement(nameInput.text, Score.Instance.finalScore) );
        nameInput.text = "";
        _scoreAdded = true;
        inputField.SetActive(false);
        
    }
}
