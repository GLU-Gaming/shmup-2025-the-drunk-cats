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

        Vector3 direction = (player.position - transform.position).normalized;

        rbBullet.linearVelocity = direction * 7f;

        tfBullet.rotation = Quaternion.LookRotation(direction);



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
