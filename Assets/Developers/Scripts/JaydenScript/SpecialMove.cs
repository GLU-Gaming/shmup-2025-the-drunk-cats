using UnityEngine;

public class SpecialMove : MonoBehaviour
{
    [SerializeField] private GameManager game;
    public float speed = 20f;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        game = FindFirstObjectByType<GameManager>();
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crow"))
        {
            game.playerScore += 10;
        }
        else if (collision.gameObject.CompareTag("Frog"))
        {
            game.playerScore += 10;
        }
        else if (collision.gameObject.CompareTag("Rat"))
        {
            game.playerScore += 10;
        }
    }

    public
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
