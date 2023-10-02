using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public bool died = false;
    public bool isGrounded;
    public bool didFinish = false;
    public static event Action<GameState> OnGameStateChange;

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
        UpdateGameState(GameState.Alive);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (state)
        {
            case GameState.Alive:
                died = false;
                break;
            case GameState.Dead:
                died = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnGameStateChange?.Invoke(newState);
    }
    public enum GameState
    {
        Alive,
        Dead
    }
    
}