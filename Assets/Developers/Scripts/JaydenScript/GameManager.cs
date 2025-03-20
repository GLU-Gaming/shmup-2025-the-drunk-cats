using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    public int playerHealth = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(player.PlayerHit());
        }
        if (playerHealth > 0)
        {

        } else
        {
            SceneManager.LoadScene(3);
        }
    }
}
