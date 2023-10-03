using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSelectButtonsSFX : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private AudioSource audioSource; 
    [SerializeField] private AudioClip buttonClick;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(buttonClick);
    }
}
