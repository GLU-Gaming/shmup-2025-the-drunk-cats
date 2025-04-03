using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SpawnEvilEnemies : MonoBehaviour
{
    private float xCrow;
    private float yCrow;
    private float xRat;
    private float yRat;
    private float xFrog;
    private float yFrog;
    private int round = 1;

    [SerializeField] GameObject[] evilEnemies;
    public List<GameObject> spawnedEnemies;

    void Start()
    {
        spawnedEnemies = new List<GameObject>();
        StartCoroutine(Round1());
    }

    void Update()
    {
        if (spawnedEnemies.Count == 0 && round == 2)
        {
            StartCoroutine(Round2());
        }
        if (spawnedEnemies.Count == 0 && round == 2)
        {
            StartCoroutine(Round2());
        }
    }
    private IEnumerator Round1()
    {

        for (int crowAmount = 0; crowAmount < 5; crowAmount++)
        {
            yield return new WaitForSeconds(1f);
            xCrow = Random.Range(12f, 14f);
            yCrow = Random.Range(-4f, 4f);
            GameObject crow = Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
            spawnedEnemies.Add(crow);
        }
        round++;
        for (int frogAmount = 0; frogAmount < 1; frogAmount++)
        {
            yield return new WaitForSeconds(2f);
            xFrog = Random.Range(12f, 14f);
            yFrog = Random.Range(-4f, 4f);
            GameObject Frog = Instantiate(evilEnemies[2], new Vector3(xFrog, yFrog, 0), Quaternion.identity);
            spawnedEnemies.Add(Frog);
        }
    }

    private IEnumerator Round2()
    {
        Debug.Log("Round 2");
        yield return new WaitForSeconds(2f);
        for (int crowAmount = 0; crowAmount < 5; crowAmount++)
        {
            yield return new WaitForSeconds(2f);
            xCrow = Random.Range(12f, 14f);
            yCrow = Random.Range(-4f, 4f);
            GameObject crow = Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
            spawnedEnemies.Add(crow);
        }
        for (int crowAmount = 0; crowAmount < 5; crowAmount++)
        {
            yield return new WaitForSeconds(2f);
            xCrow = Random.Range(12f, 14f);
            yCrow = Random.Range(-4f, 4f);
            GameObject crow = Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
            spawnedEnemies.Add(crow);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }
}

