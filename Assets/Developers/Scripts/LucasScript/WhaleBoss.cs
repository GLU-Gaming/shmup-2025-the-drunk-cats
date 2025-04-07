using UnityEngine;

public class WhaleBoss : MonoBehaviour
{
    [SerializeField] Transform tfWhale;
    [SerializeField] Rigidbody rbWhale;

    private float speedWhale = 0.2f;

    private float boostedSpeed;

    private void Update()
    {
        MoveWhale();
        DecideHeight();

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

    }


