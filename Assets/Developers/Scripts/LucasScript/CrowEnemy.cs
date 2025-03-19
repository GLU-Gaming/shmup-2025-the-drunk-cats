using UnityEngine;

public class CrowEnemy : MonoBehaviour
{

    private float speedCrow;

    [SerializeField] Rigidbody rbCrow;

    [SerializeField] Transform tfCrow;

    private float healthCrow = 3f;
    void Start()
    {

        speedCrow = 0.03f;

    }


    void Update()
    {

        CheckHealth();

        MoveCrow();

    }

    private void OnTriggerEnter(Collider other)
    {

        DashToPlayer();
        
    }

    private void MoveCrow()
    {
        speedCrow -= Time.deltaTime;

        tfCrow.position = new Vector3(speedCrow -= transform.position.x, transform.position.y, transform.position.z);

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

        

    }
}
