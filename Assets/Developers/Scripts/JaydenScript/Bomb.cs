using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Player player;
    public GameObject bombPrefab;
    [SerializeField] Rigidbody rb;
    public float throwForce = 1f;
    public float throwUpForce = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<Player>();

        Vector3 force = transform.forward * throwForce + transform.up * throwUpForce;
        rb.AddForce(force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
