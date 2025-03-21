using UnityEditor.Rendering.Analytics;
using UnityEngine;
using UnityEngine.UIElements;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameManager game;
    public float speed = 10f;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            game.playerScore += 10;
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            game.playerScore += +10;
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Enemy"))
        {
            game.playerScore += +10;
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
