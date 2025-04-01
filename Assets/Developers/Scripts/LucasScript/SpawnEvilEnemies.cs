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
            StartCoroutine(Round1());
            round++;
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
        for (int ratAmount = 0; ratAmount < 5; ratAmount++)
        {
            yield return new WaitForSeconds(0.8f);
            xRat = Random.Range(12f, 14f);
            yRat = Random.Range(-4f, -4f);
            GameObject rat = Instantiate(evilEnemies[1], new Vector3(xRat, yRat, 0), Quaternion.identity);
            spawnedEnemies.Add(rat);
        }
        for (int crowAmount = 0; crowAmount < 5; crowAmount++)
        {
            yield return new WaitForSeconds(2f);
            xCrow = Random.Range(12f, 14f);
            yCrow = Random.Range(-4f, 4f);
            GameObject crow = Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
            spawnedEnemies.Add(crow);
        }
        round++;
    }

    private IEnumerator Round2()
    {
        yield return new WaitForSeconds(2f);
       Debug.Log("Round 2");
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (spawnedEnemies.Contains(enemy))
        {
            spawnedEnemies.Remove(enemy);
        }
    }
}

