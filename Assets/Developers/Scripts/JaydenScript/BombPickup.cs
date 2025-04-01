using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombPickup : MonoBehaviour
{
    public Player player;
    public GameObject Pickup;
    float waitTime;
    float minTime = 1f;
    float maxTime = 10f;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.pickupActivated = true;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
