using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameManager game;
    public Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetHealth()
    {
        slider.value = game.playerHealth;
    }
    // Update is called once per frame
    void Update()
    {
        SetHealth();
    }
}
