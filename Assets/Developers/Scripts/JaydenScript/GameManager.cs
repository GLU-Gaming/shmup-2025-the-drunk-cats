using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private Player player;
    public GameObject Pickup;
    float waitTime;
    float minTime = 1f;
    float maxTime = 10f;
    public int playerHealth = 10;
    public int playerScore = 0;
    public int specialMoveValue = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        StartCoroutine(SpawnPickup());
    }

    private IEnumerator SpawnPickup()
    {
        while (true)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-7, 3), Random.Range(-2, 4), 0);
            waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            Instantiate(Pickup, spawnLocation, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(player.PlayerHit());
        }
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
        PlayerPrefs.SetInt("finalscore", playerScore);
    }
}
    