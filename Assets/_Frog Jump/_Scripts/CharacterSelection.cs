using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characters;

    [SerializeField] private int selectedCharacter = 0;
    private int _characterCount;

    private void Start()
    {
        _characterCount = characters.Length;
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % _characterCount;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += _characterCount;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void MainMenu()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }
}
