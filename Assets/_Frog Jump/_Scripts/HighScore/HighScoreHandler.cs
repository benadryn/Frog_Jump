using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    private List<HighScoreElement> _highScoreList = new List<HighScoreElement>();
    [SerializeField] private int maxCount = 3;
    [SerializeField] private string filename;
    private bool _highScoreLoaded;

    public delegate void OnHighScoreListChanged(List<HighScoreElement> list);

    public static event OnHighScoreListChanged onHighScoreListChanged;
    
    private void Update()
    {
        if (!_highScoreLoaded)
        {
            LoadHighScores();
        }
    }

    private void LoadHighScores()
    {
        _highScoreList = FileHandler.ReadListFromJSON<HighScoreElement>(filename);

        while (_highScoreList.Count > maxCount)
        {
            _highScoreList.RemoveAt(maxCount);
        }
        
        onHighScoreListChanged?.Invoke(_highScoreList);
        _highScoreLoaded = false;
    }

    private void SaveHighScore()
    {
        FileHandler.SaveToJSON<HighScoreElement>(_highScoreList, filename);
    }


    public bool CheckForHighScore(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= _highScoreList.Count || element.score > _highScoreList[i].score)
            {
                return true;
            }
        }
        return false;
    }

    public void AddHighScoreIfPossible(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= _highScoreList.Count || element.score > _highScoreList[i].score)
            {
                // add new high score
                _highScoreList.Insert(i, element);
                
                while (_highScoreList.Count > maxCount)
                {
                    _highScoreList.RemoveAt(maxCount);
                }
                
                SaveHighScore();

                onHighScoreListChanged?.Invoke(_highScoreList);

                break;
            }
        }
    }
}
