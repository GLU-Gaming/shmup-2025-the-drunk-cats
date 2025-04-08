using UnityEngine;

public class Feather : MonoBehaviour
{

    [SerializeField] Rigidbody rbBullet;
    [SerializeField] Transform tfBullet;

    private float timer;

    private Transform player;



    void Start()
    {

        //Spawn with a velocity.
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rbBullet.linearVelocity = transform.right * -7f;

        Vector3 direction = player.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        tfBullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));


    }

    private void Update()
    {

        //If bullet is alive more then 4 seconds destroy it.
        timer += Time.deltaTime;

        if (timer >= 4f)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
