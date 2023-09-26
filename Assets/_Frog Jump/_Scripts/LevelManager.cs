using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private Image loadingSlider;
    
    private float _target;
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public async void LoadScene(string sceneName)
    {
        loadingSlider.fillAmount = 0;
        
        mainMenu.SetActive(false); 
        loadingScreen.SetActive(true);
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        

        do
        {
            // Artificial loading
            await Task.Delay(100);
            _target = scene.progress;

        } while (scene.progress < 0.9f);
        
        // Artificial loading
        await Task.Delay(1000);
        scene.allowSceneActivation = true;
        if(sceneName == "StartMenu") mainMenu.SetActive(true);
        loadingScreen.SetActive(false);
        _target = 0;
    }

    private void Update()
    {
        if (_target > 0)
        {
            loadingSlider.fillAmount = Mathf.MoveTowards(loadingSlider.fillAmount, _target, 3 * Time.deltaTime);
        }
    }
}
