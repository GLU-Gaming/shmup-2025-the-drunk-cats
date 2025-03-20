using UnityEditor.Rendering.Analytics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
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
