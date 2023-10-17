using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject highScoreUIElementPrefab;
    [SerializeField] private Transform elementWrapper;

    private List<GameObject> _uiElements = new List<GameObject>();


    private void OnEnable()
    {
        HighScoreHandler.onHighScoreListChanged += UpdateUi;
    }

    private void OnDisable()
    {
        HighScoreHandler.onHighScoreListChanged -= UpdateUi;
    }

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }

    private void UpdateUi(List<HighScoreElement> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            HighScoreElement el = list[i];
            
            if (el != null && el.score > 0)
            {
                if (i >= _uiElements.Count)
                {
                    var inst = Instantiate(highScoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent(elementWrapper, false);
                    
                    _uiElements.Add(inst);
                }
            
                var texts = _uiElements[i].GetComponentsInChildren<TMP_Text>();
                texts[0].text = el.playerName;
                texts[1].text = el.score.ToString();
            }
        }

    }
}
