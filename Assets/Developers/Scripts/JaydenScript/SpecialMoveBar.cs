using UnityEngine;
using UnityEngine.UI;

public class SpecialMoveBar : MonoBehaviour
{
    [SerializeField] private GameManager game;
    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetSpecialMoveProgress()
    {
        slider.value = game.specialMoveValue;
    }
    // Update is called once per frame
    void Update()
    {
        SetSpecialMoveProgress();
    }
}
