using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] Rigidbody rbBullet;

    private float timer;



    void Start()
    {

        rbBullet.linearVelocity = transform.right * -20f;

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);

        }

    }

    private void Update()
    {

        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            Destroy(gameObject);
        }
        
    }
}
