using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    // [SerializeField] private string fileName;
    [SerializeField] private HighScoreHandler _highScoreHandler;

    [SerializeField] private GameObject inputField;

    // private List<InputEntry> _entries = new List<InputEntry>();


    private void Start()
    {
        // _entries = FileHandler.ReadListFromJSON<InputEntry>(fileName);
    }

    public void AddNameToList()
    {
    //     _entries.Add(new InputEntry(nameInput.text , Score.Instance.finalScore));
        
        // FileHandler.SaveToJSON<InputEntry>(_entries, fileName);
        
        _highScoreHandler.AddHighScoreIfPossible(new HighScoreElement(nameInput.text, Score.Instance.finalScore) );
        nameInput.text = "";
        
        inputField.SetActive(false);
        
    }
}
