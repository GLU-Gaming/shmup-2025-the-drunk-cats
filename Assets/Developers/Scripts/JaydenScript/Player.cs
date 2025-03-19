using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    private float moveY;
    private float moveX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY += 1;
        if (Input.GetKey(KeyCode.S)) moveY -= 1;
        if (Input.GetKey(KeyCode.A)) moveX -= 1;
        if (Input.GetKey(KeyCode.D)) moveX += 1;

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
