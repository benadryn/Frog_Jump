using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public void RestartGame(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
        Score.Instance?.ResetScore();
    }
}
