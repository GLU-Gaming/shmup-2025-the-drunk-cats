using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class SpawnEvilEnemies : MonoBehaviour
{
    [SerializeField] AudioClip AudioCrow;
    [SerializeField] AudioClip AudioRat;
    [SerializeField] AudioClip AudioFrog;
    [SerializeField] AudioClip BossTheme;
    [SerializeField] AudioClip MainTheme;
    public AudioSource audioSource;

    [SerializeField] private GameManager game;
    public GameObject player;
    public GameObject bossWhale;
    private float xCrow;
    private float yCrow;
    private float xRat;
    private float yRat;
    private float xFrog;
    private float yFrog;
    public int round = 1;
    public bool roundIsBusy = false;

    [SerializeField] GameObject[] evilEnemies;
    public List<GameObject> spawnedEnemies;

    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        spawnedEnemies = new List<GameObject>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Round(8, 0, 0));
        audioSource.PlayOneShot(MainTheme);
    }

    void Update()
    {
        if (spawnedEnemies.Count == 0)
        {
            if (round == 2 && !roundIsBusy)
            {
                StartCoroutine(Round(10, 0, 0));
            }
            if (round == 3 && !roundIsBusy)
            {
                StartCoroutine(Round(5, 5, 0));
            }
            else if (round == 4 && !roundIsBusy)
            {
                StartCoroutine(Round(8, 10, 0));
            }
            else if (round == 5 && !roundIsBusy) 
            {
                StartCoroutine(Round(0, 0, 5));
            }
            else if (round == 6 && !roundIsBusy)
            {
                StartCoroutine(Round(0, 10, 5));
            }
            else if (round == 7 && !roundIsBusy)
            {
                StartCoroutine(Round(5, 8, 5));
            }
            else if (round == 8 && !roundIsBusy)
            {
                StartCoroutine(Round(8, 8, 8));
            }
            else if (round == 9 && !roundIsBusy)
            {
                StartCoroutine(Round(10, 8, 8));
            }
            else if (round == 10 && !roundIsBusy)
            {
                StartCoroutine(Round(12, 8, 8));
            }
            else if (round == 11 && !roundIsBusy)
            {
                game.isBossBattleActive = true;
                StartCoroutine(BossFight());
            }
            else if (spawnedEnemies.Count == 0 && !roundIsBusy)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    private IEnumerator Round(int crowAmount, int ratAmount, int frogAmount)
    {
        roundIsBusy = true;
        if (crowAmount > 0)
        {
            audioSource.PlayOneShot(AudioCrow);
        }
        for (int i = 0; i < crowAmount; i++)
        {
                yield return new WaitForSeconds(1f);
            xCrow = Random.Range(12f, 14f);
            yCrow = Random.Range(-4f, 4f);
            GameObject crow = Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
            spawnedEnemies.Add(crow);
        }
        if (ratAmount > 0)
        {
            audioSource.PlayOneShot(AudioRat);
        }
        for (int i = 0; i < ratAmount; i++)
        {
            yield return new WaitForSeconds(0.8f);
            xRat = Random.Range(12f, 14f);
            yRat = Random.Range(-4f, -4f);
            GameObject rat = Instantiate(evilEnemies[1], new Vector3(xRat, yRat, 0), Quaternion.identity);
            spawnedEnemies.Add(rat);
        }

        if (frogAmount > 0)
        {
            audioSource.PlayOneShot(AudioFrog);
        }
        for (int i = 0; i < frogAmount; i++)
        {
            yield return new WaitForSeconds(2f);
            xFrog = Random.Range(12f, 14f);
            yFrog = Random.Range(-4f, 4f);
            GameObject frog = Instantiate(evilEnemies[2], new Vector3(xFrog, yFrog, 0), Quaternion.Euler(0, 180, 0));
            spawnedEnemies.Add(frog);
        }
        round++;
        roundIsBusy = false;
    }
    public IEnumerator BossFight()
    {
        roundIsBusy = true;
        yield return new WaitForSeconds(2f);
        game.playerHealth = 8;
        audioSource.Stop();
        audioSource.PlayOneShot(BossTheme);
        Vector3 bossLocation = new Vector3(13, 0, 0);
        GameObject bossWhale = Instantiate(evilEnemies[3], bossLocation, transform.rotation);
        player.transform.position = new Vector3(-5, 0, 0);
        spawnedEnemies.Add(bossWhale);
        round++;
        roundIsBusy = false;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }
}

