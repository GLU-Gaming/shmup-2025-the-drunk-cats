using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager game;
    private Renderer playerRenderer;
    private Collider playerCollider;
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        playerCollider = GetComponent<Collider>();
    }

    public IEnumerator PlayerHit()
    {
        playerCollider.enabled = false;
        game.playerHealth -= 1;
        for (float i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.15f);
            playerRenderer.enabled = false;
            yield return new WaitForSeconds(0.15f);
            playerRenderer.enabled = true;
        }
        playerCollider.enabled = true;

    }
    public void shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            shoot();
            nextFireTime = Time.time + fireRate;
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * speed);
        } else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.down * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * speed); 
        } else if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * speed);

        }
    }
}