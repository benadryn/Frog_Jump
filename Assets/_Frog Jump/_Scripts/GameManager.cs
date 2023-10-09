using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState state;
    public bool died = false;
    public bool isGrounded;
    public bool didFinish = false;
    public bool gameEnd = false;

    private bool _isSfxPlaying = false;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip successSfx;
    [SerializeField] private GameObject endScreen;
    
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
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (didFinish && !_isSfxPlaying)
        {
            _audioSource.PlayOneShot(successSfx);
            _isSfxPlaying = true;
        }
        else if(!didFinish)
        {
            _isSfxPlaying = false;
        }

        if (endScreen)
        {
            EndMessage();
            
        }
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
            case GameState.GameEnd:
                gameEnd = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        OnGameStateChange?.Invoke(newState);
    }
    public enum GameState
    {
        Alive,
        Dead,
        GameEnd
    }

    private void EndMessage()
    {
        endScreen.SetActive(gameEnd);
    }
}
