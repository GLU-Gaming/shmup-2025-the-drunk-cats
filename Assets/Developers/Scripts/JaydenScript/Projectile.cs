using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    private Player player;
    [SerializeField] private GameManager game;
    public float speed = 10f;
    [SerializeField] Rigidbody rb;
    public AudioClip enemyHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();
        game = FindFirstObjectByType<GameManager>();
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crow"))
        {
            player.audioSource.PlayOneShot(enemyHit);
            game.playerScore += 10;
            game.specialMoveValue += 5;
            Destroy(gameObject);
        } 
        else if (collision.gameObject.CompareTag("Frog"))
        {
            player.audioSource.PlayOneShot(enemyHit);
            game.playerScore += +10;
            game.specialMoveValue += 5;
            Destroy(gameObject);
        } 
        else if (collision.gameObject.CompareTag("Rat"))
        {
            player.audioSource.PlayOneShot(enemyHit);
            game.playerScore += +10;
            game.specialMoveValue += 5;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
