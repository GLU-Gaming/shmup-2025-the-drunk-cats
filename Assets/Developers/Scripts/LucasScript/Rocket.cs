using UnityEngine;

public class Rocket : MonoBehaviour
{

    private Transform player;

    [SerializeField] Rigidbody rbRocket;

    private float speedRocket;

    private float timer;
    void Start()
    {
        speedRocket = 5.4f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        rbRocket.linearVelocity = transform.right * speedRocket;


        if (timer >= 0.5f)
        {

            speedRocket = -3f;

            Vector3 direction = player.position - transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
        }

        if (timer >= 4f)
        {
            Destroy(gameObject);
        }


    }
}
