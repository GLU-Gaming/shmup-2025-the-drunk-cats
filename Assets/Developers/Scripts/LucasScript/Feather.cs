using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] Rigidbody rbBullet;
    [SerializeField] Transform tfBullet;

    private float timer;



    void Start()
    {

        //Spawn with a velocity.
        rbBullet.linearVelocity = transform.right * -10f;
        tfBullet.rotation = new Quaternion(45, 0, 0, 0);

    }

    private void Update()
    {

        //If bullet is alive more then 2 seconds destroy it.
        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            Destroy(gameObject);
        }
        
    }
}
