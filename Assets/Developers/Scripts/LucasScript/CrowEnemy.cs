using UnityEngine;

public class CrowEnemy : MonoBehaviour
{

    private float speedCrow;

    [SerializeField] Rigidbody rbCrow;

    [SerializeField] Transform tfCrow;

    private float healthCrow = 3f;
    void Start()
    {

        MoveCrow();
        
    }


    void Update()
    {

        CheckHealth();
        
    }

    private void MoveCrow()
    {

        speedCrow = -1f;

        rbCrow.linearVelocity = transform.right * speedCrow;

        tfCrow.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

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

        //there will be script here trust

    }
}
