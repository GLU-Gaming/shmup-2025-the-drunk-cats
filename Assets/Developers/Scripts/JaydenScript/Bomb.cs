using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bomb : MonoBehaviour
{
    private Player player;
    public GameObject bombPrefab;
    [SerializeField] Rigidbody rb;
    public float throwForce = 1f;
    public float throwUpForce = 1f;
    public float radius = 1f;
    public float force = 200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();

        Vector3 force = transform.forward * throwForce + transform.up * throwUpForce;
        rb.AddForce(force, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crow") || collision.gameObject.CompareTag("Frog") || collision.gameObject.CompareTag("Rat"))
        {
            Explode();
        }
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
                Destroy(nearbyObject.gameObject);
        }

        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
