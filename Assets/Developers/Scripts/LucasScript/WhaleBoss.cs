using UnityEngine;

public class WhaleBoss : MonoBehaviour
{
    [SerializeField] Transform tfWhale;
    [SerializeField] Rigidbody rbWhale;

    private float speedWhale = 0.2f;

    private void Update()
    {
        rbWhale.linearVelocity = (transform.up * (speedWhale * 3f));
        DecideHeight();

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

}


