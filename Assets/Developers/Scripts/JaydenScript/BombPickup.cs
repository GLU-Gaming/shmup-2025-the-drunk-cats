using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombPickup : MonoBehaviour
{
    public Player player;
    public GameObject Pickup;
    float waitTime;
    float minTime = 15f;
    float maxTime = 30f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        StartCoroutine(SpawnPickup());
    }

    private IEnumerator SpawnPickup()
    {
        Vector3 spawnLocation = new Vector3(Random.Range(-7, 3), Random.Range(4, -2), 0);
        waitTime = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        Instantiate(Pickup, spawnLocation, transform.rotation);
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
