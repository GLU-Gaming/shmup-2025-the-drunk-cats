using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BombPickup : MonoBehaviour
{
    public Player player;
    public GameObject Pickup;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
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
