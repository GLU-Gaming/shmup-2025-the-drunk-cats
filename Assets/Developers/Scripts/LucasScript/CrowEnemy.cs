using UnityEngine;

public class CrowEnemy : MonoBehaviour
{

    private float speedCrow;

    [SerializeField] Rigidbody rbCrow;

    [SerializeField] Transform tfCrow;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform tfBulletSpawn;

    private Transform player;

    private float healthCrow = 2f;

    private float timerCrow;

    private float dashTimer;    

    private bool dashPlayer;

    private SpawnEvilEnemies spawnManager;

    private float leftBoundary = -15f;
    private float topBoundary = 10f;
    private float bottomBoundary = -10f;

    private bool lockedOn;
    void Start()
    {

        speedCrow = -3f;

        MoveCrow();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        spawnManager = FindFirstObjectByType<SpawnEvilEnemies>();
    }


    void Update()
    {

        CheckHealth();

        ShootFeather();

        DestroyCrow();

        if (lockedOn)
        { 
        
            dashTimer += Time.deltaTime;

            if (dashTimer <= 1.3f)
            {

                ChangeDirection();

            }
       
        }

        if (dashTimer >= 1f)
        {

            DashToPlayer();

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            RemoveCrow();
        }

        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            healthCrow -= 1f;
        }

        else if (collision.gameObject.CompareTag("PlayerSuperProjectile"))
        {
            RemoveCrow();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //If the Sphere collider has detected an object with the tag Player activate dash.
        if (other.CompareTag("Player"))
        {
            dashPlayer = true;

            lockedOn = true;

            rbCrow.linearVelocity = transform.right * 0;

        }

    }

    private void MoveCrow()
    {

        rbCrow.linearVelocity = transform.right * speedCrow;

    }

    private void CheckHealth()
    {

        //If statement is true destroy the gameObject.
        if (healthCrow <= 0)
        {

            RemoveCrow();

        }

    }

    private void DashToPlayer()
    {

        speedCrow -= 0.2f;

        MoveCrow();

    }

    private void DestroyCrow()
    {
        if (tfCrow.position.x < leftBoundary || tfCrow.position.y < bottomBoundary || tfCrow.position.y > topBoundary)
        {
            RemoveCrow();
        }
    }


    private void ChangeDirection()
    {

        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

    }    

    private void ShootFeather()
    {
        
        
            timerCrow += Time.deltaTime;

            if (timerCrow >= 4f && !dashPlayer)
            {
                timerCrow = 0;

                Vector3 direction = player.position - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                tfBulletSpawn.transform.rotation = Quaternion.Euler(new Vector3(0, 90, angle + 180));

                Instantiate(bullet, tfBulletSpawn.transform.position, tfBulletSpawn.transform.rotation);
            }



    }
    private void RemoveCrow()
    {
        if (spawnManager != null)
        {
            spawnManager.RemoveEnemy(gameObject);
        }
        Destroy(gameObject);
    }

}
