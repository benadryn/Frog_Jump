using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{ 
   [SerializeField] private AudioSource audioSource; 
   [SerializeField] private AudioClip buttonHover;
   [SerializeField] private AudioClip buttonClick;

   public void OnPointerEnter(PointerEventData eventData)
   {
      audioSource.PlayOneShot(buttonHover);
   }

   public void OnPointerClick(PointerEventData eventData)
   {
      audioSource.PlayOneShot(buttonClick);
   }
}
