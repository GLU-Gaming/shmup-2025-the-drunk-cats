using UnityEngine;

public class SpawnEvilEnemies : MonoBehaviour
{

    private float xCrow;
    private float yCrow;
    private float xRat;
    private float yRat;

    [SerializeField] float timer;

    [SerializeField] GameObject[] evilEnemies;
    void Start()
    {
       
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            SpawnEnemies();
            timer = 0;
        }
    }

    private void SpawnEnemies()
    {
        xCrow = Random.Range(12f, 14f);
        yCrow = Random.Range(-4f, 4f);
        xRat = Random.Range(12f, 14f);
        yRat = Random.Range(-4f, -4f);

        Instantiate(evilEnemies[0], new Vector3(xCrow, yCrow, 0), Quaternion.identity);
        Instantiate(evilEnemies[1], new Vector3(xRat, yRat, 0), Quaternion.identity);
    }
}
