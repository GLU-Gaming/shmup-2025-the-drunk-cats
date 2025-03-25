using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class CrowEnemy : MonoBehaviour
{

    private float speedCrow;

    [SerializeField] Rigidbody rbCrow;

    [SerializeField] Transform tfCrow;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform tfBulletSpawn;

    private Transform player;

    private float healthCrow = 3f;

    private float timerCrow;

    private float dashTimer;    

    private bool dashPlayer;

    private bool lockedOn;
    void Start()
    {

        speedCrow = -1.5f;

        MoveCrow();

    }


    void Update()
    {

        CheckHealth();

        ShootFeather();

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
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            healthCrow -= 1f;
        }

        else if (collision.gameObject.CompareTag("PlayerSuperProjectile"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //If the Sphere collider has detected an object with the tag Player activate dash.
        if (other.CompareTag("Player"))
        {
            dashPlayer = true;

            lockedOn = true;

            player = other.GetComponent<Transform>();

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

            Destroy(gameObject);

        }

    }

    private void DashToPlayer()
    {

        speedCrow += 0.4f;

        MoveCrow();

    }

    private void ChangeDirection()
    {

        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }    

    private void ShootFeather()
    {
        timerCrow += Time.deltaTime;

        if (timerCrow >= 2f && !dashPlayer)
        {
            timerCrow = 0f;

            Instantiate(bullet, tfBulletSpawn.transform.position, new Quaternion());
        }

    }


}
