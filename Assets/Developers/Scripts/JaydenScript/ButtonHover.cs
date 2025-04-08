using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private AudioClip hoverSound; // Assign this in the Inspector
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the parent or the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }
}
