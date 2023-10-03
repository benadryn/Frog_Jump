using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance;
    
    private static int _score = 0;
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

    public void AddScore(int point)
    {
        _score += point;
        foreach (var score in scoreText)
        {
            score.text = "Score: " + _score;
            
        }
    }

    public void ReduceScore()
    {
        if (_score < 1) return;
        _score--;
        foreach (var score in scoreText)
        {
            score.text = "Score: " + _score;
            
        }
    }
}
