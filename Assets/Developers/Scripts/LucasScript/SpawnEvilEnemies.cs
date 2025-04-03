using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using NUnit.Framework;

public class SpawnEvilEnemies : MonoBehaviour
{
    private float xCrow;
    private float yCrow;
    private float xRat;
    private float yRat;
    private float xFrog;
    private float yFrog;
    public int round = 1;
    bool roundIsBusy = false;

    [SerializeField] GameObject[] evilEnemies;
    public List<GameObject> spawnedEnemies;

    void Start()
    {
        spawnedEnemies = new List<GameObject>();
        //StartCoroutine(Round1());
        StartCoroutine(Round(8, 0, 0));
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
                StartCoroutine(Round(10, 5, 0));
            }
            //else if (round == 3)
            //{
            //    StartCoroutine(Round3());
            //}
            //else if (round == 4)
            //{
            //    StartCoroutine(Round4());
            //}
        }
    }

    private IEnumerator Round(int crowAmount, int ratAmount, int frogAmount)
    {
        roundIsBusy = true;
        for (int i = 0; i < crowAmount; i++)
        {
            yield return new WaitForSeconds(1f);
            xCrow = Random.Range(12f, 14f);
            yCrow = Random.Range(-4f, 4f);
            GameObject crow = Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
            spawnedEnemies.Add(crow);
        }

        for (int i = 0; i < ratAmount; i++)
        {
            yield return new WaitForSeconds(0.8f);
            xRat = Random.Range(12f, 14f);
            yRat = Random.Range(-4f, -4f);
            GameObject rat = Instantiate(evilEnemies[1], new Vector3(xRat, yRat, 0), Quaternion.identity);
            spawnedEnemies.Add(rat);
        }

        for (int i = 0; i < frogAmount; i++)
        {
            yield return new WaitForSeconds(2f);
            xFrog = Random.Range(12f, 14f);
            yFrog = Random.Range(-4f, 4f);
            GameObject frog = Instantiate(evilEnemies[2], new Vector3(xFrog, yFrog, 0), Quaternion.identity);
            spawnedEnemies.Add(frog);
        }
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

