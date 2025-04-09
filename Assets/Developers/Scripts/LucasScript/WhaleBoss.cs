using UnityEngine;
using UnityEngine.SceneManagement;

public class WhaleBoss : MonoBehaviour
{
    [SerializeField] Transform tfWhale;
    [SerializeField] Rigidbody rbWhale;

    private float health;

    private float speedWhale = 0.2f;

    private float boostedSpeed;

    private void Update()
    {
        MoveWhale();
        DecideHeight();

        if (health >= 40)
        {

            SceneManager.LoadScene("WinScreen");

        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            Debug.Log("Player detected");

            if (boostedSpeed >= 0)
            {
                boostedSpeed -= 0.05f;
            }

            else if (boostedSpeed <= 0)
            {
                boostedSpeed += 0.05f;
            }

            if (tfWhale.position.y >= 5f || tfWhale.position.y <= -5f)
            {
                boostedSpeed = 0f;
            }

                Debug.Log(boostedSpeed);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of range");

            if (speedWhale >= 0)
            {
                boostedSpeed = 5f;
            }
            
            else if (speedWhale <= 0)
            {
                boostedSpeed = -5f;
            }

            Debug.Log($"New speedWhale: {speedWhale}");
        }
    }

    private void DecideHeight()
    {
        if (tfWhale.position.y >= 5f)
        {
            speedWhale = -0.2f;
        }
        else if (tfWhale.position.y <= -5f)
        {
            speedWhale = 0.2f;
        }
    }

 

    private void MoveWhale()
    {
        rbWhale.linearVelocity = transform.up * (speedWhale * 3f + boostedSpeed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            RailCannon railCannon = collision.contacts[0].thisCollider.GetComponent<RailCannon>();

            Minigun minigunS = collision.contacts[0].thisCollider.GetComponent<Minigun>();

            if (railCannon != null)
            {
                railCannon.TakeDamage();

                health ++;
            }
            else if (minigunS != null)
            {
                minigunS.TakeDamageTwo();
                health ++;
            }
        }
    }

}


