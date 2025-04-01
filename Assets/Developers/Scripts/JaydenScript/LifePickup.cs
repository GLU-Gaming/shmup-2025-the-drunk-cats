using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LifePickup : MonoBehaviour
{
    [SerializeField] private GameManager game;
    public GameObject lifePickup;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (game.playerHealth < 10)
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
