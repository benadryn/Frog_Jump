using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] private Image loadingSlider;
    [SerializeField] private GameObject successScreen;
    
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

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }

    private void Update()
    {
        if (_target > 0)
        {
            loadingSlider.fillAmount = Mathf.MoveTowards(loadingSlider.fillAmount, _target, 3 * Time.deltaTime);
        }
        SuccessMessage();
    }

    private void SuccessMessage()
    {
        switch (GameManager.Instance?.didFinish)
        {
            case true:
                successScreen.SetActive(true);
                break;
            case false:
                successScreen.SetActive(false);
                break;
        }
    }

    
    
    }
