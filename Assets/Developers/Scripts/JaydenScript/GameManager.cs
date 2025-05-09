using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    private Player player;
    public GameObject pickup;
    public GameObject lifePickup;
    public SpawnEvilEnemies SpawnEvilEnemies;
    float waitTime;
    float minTimeBomb = 40f;
    float maxTimeBomb = 80f;
    float minTimeHealth = 40f;
    float maxTimeHealth = 80f;
    public int playerHealth = 8;
    public int playerScore = 0;
    public int specialMoveValue = 0;
    public bool isBossBattleActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        SpawnEvilEnemies = FindFirstObjectByType<SpawnEvilEnemies>();
        StartCoroutine(SpawnPickup());
        StartCoroutine(SpawnLifePickup());

    }

    private IEnumerator SpawnPickup()
    {
        while (true)
        {
            if (SpawnEvilEnemies.round < 11 && !isBossBattleActive)
            {
                Vector3 spawnLocation = new Vector3(Random.Range(-7, 0), Random.Range(-2, 4), 0);
                waitTime = Random.Range(minTimeBomb, maxTimeBomb);
                yield return new WaitForSeconds(waitTime);
                Instantiate(pickup, spawnLocation, Quaternion.identity);
            }
            else
            {
                yield return null;
            }
        }
    }

    private IEnumerator SpawnLifePickup()
    {
        while (true)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-7, 0), Random.Range(-2, 4), 0);
            waitTime = Random.Range(minTimeHealth, maxTimeHealth);
            yield return new WaitForSeconds(waitTime);
            Instantiate(lifePickup, spawnLocation, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }
        PlayerPrefs.SetInt("finalscore", playerScore);
    }
}
    