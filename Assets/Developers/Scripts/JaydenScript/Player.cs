using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager game;
    [SerializeField] private BombPickup bombPickup;
    public GameObject pauseMenuUI;
    public GameObject qButton;
    public bool pickupActivated = false;
    public GameObject Pickup;
    public GameObject strongAttack;
    private Renderer[] renderers;
    private Collider playerCollider;
    public float speed = 10f;
    public GameObject bombPrefab;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    [SerializeField] Rigidbody rb;
    private Camera _camera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        qButton.SetActive(false);
        renderers = GetComponentsInChildren<Renderer>();
        playerCollider = GetComponent<Collider>();
        _camera = Camera.main;
    }

    public IEnumerator PlayerHit()
    {
        playerCollider.enabled = false;
        game.playerHealth -= 1;
        for (float i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.15f);
            SetRenderersEnabled(false);
            yield return new WaitForSeconds(0.15f);
            SetRenderersEnabled(true);
        }
        playerCollider.enabled = true;
    }

    private void SetRenderersEnabled(bool enabled)
    {
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = enabled;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Frog"))
        {
            StartCoroutine(PlayerHit());
        }
        else if (collision.gameObject.CompareTag("Crow"))
        {
            StartCoroutine(PlayerHit());
        }
        else if (collision.gameObject.CompareTag("Rat"))
        {
            StartCoroutine(PlayerHit());
        }

    }
    public void shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    public void specialMove()
    {
        Instantiate(strongAttack, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    public void bomb()
    {
        Instantiate(bombPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        pickupActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (game.specialMoveValue >= 200)
        {
            qButton.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                qButton.SetActive(false);
                specialMove();
                game.specialMoveValue = 0;
            }
        }
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            shoot();
            nextFireTime = Time.time + fireRate;
        }
        if (pickupActivated == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pauseMenuUI.SetActive(false);
                bomb();
            }
        }

    }

    private void screenBorder()
    {
        Vector3 screenPosition = _camera.WorldToScreenPoint(transform.position);
        Vector3 playerSize = renderers[0].bounds.size;

        Vector3 clampedScreenPosition = new Vector3(
            Mathf.Clamp(screenPosition.x, 100, Screen.width - 100),
            Mathf.Clamp(screenPosition.y, 100, Screen.height - 100),
            screenPosition.z
        );

        transform.position = _camera.ScreenToWorldPoint(clampedScreenPosition);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.up * speed);
        } 
        else if (Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.down * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * speed); 
        } 
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * speed);

        }
        screenBorder();
    }
}