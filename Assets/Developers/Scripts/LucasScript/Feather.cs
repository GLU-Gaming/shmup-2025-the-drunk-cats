using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] Rigidbody rbBullet;

    private float timer;



    void Start()
    {

        //Spawn with a velocity.
        rbBullet.linearVelocity = transform.right * -20f;

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
