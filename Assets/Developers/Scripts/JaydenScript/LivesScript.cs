using UnityEngine;
using TMPro;

public class LivesScript : MonoBehaviour
{
    [SerializeField] private GameManager game;
    public TextMeshProUGUI livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        livesText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + game.playerHealth.ToString();
    }
}
