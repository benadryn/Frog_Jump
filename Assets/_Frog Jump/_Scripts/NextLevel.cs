using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Scene _scene;
    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
        GameManager.Instance.didFinish = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_scene.buildIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                StartCoroutine(nameof(LoadLevel));
                GameManager.Instance.didFinish = true;
            }
            else
            {
                // TEMPORARY Fix later
                Debug.Log(_scene.buildIndex + ":::: " + SceneManager.sceneCountInBuildSettings);
                Debug.Log("triggering");
            }
        }
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(4);
        LevelManager.Instance.LoadLevel(_scene.buildIndex + 1);
    }
}
