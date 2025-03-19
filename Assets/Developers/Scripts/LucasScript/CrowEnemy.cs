using UnityEngine;

public class CrowEnemy : MonoBehaviour
{

    private float speedCrow;

    [SerializeField] Rigidbody rbCrow;

    [SerializeField] Transform tfCrow;

    private Transform player;

    private float healthCrow = 3f;
    void Start()
    {

        speedCrow = -1.5f;

        MoveCrow();

    }


    void Update()
    {

        CheckHealth();

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Transform>();

        ChangeDirection();

        DashToPlayer();

    }

    private void MoveCrow()
    {

        rbCrow.linearVelocity = transform.right * speedCrow;

    }

    private void CheckHealth()
    {

        if (healthCrow <= 0)
        {

            Destroy(gameObject);

        }

    }

    private void DashToPlayer()
    {

        speedCrow = 15f;

        MoveCrow();

    }

    private void ChangeDirection()
    {

        Vector3 direction = player.position - transform.position;


        //Some magic line that makes it turn
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }    
}
