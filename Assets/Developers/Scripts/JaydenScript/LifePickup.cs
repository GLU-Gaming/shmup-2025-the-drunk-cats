using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LifePickup : MonoBehaviour
{
    public Player player;
    [SerializeField] private GameManager game;
    public GameObject lifePickup;
    public AudioClip wrenchPickupSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        game = FindFirstObjectByType<GameManager>();
        game.playerHealth = 8;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.audioSource.PlayOneShot(wrenchPickupSound);
            Destroy(gameObject);
            if (game.playerHealth < 8)
            {
                game.playerHealth++;
            }
        }
    }
    // Update  is called once per frame
    void Update()
    {
        
    }
}
