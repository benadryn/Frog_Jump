using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] endLevel;
    [SerializeField] private int secondsNewLevel = 2;
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
                int randomParticle = Random.Range(0, endLevel.Length - 1);
                Debug.Log(randomParticle);
                endLevel[randomParticle].Play();
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
        yield return new WaitForSeconds(secondsNewLevel);
        LevelManager.Instance.LoadLevel(_scene.buildIndex + 1);
    }
}
