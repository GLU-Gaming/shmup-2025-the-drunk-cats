using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    [SerializeField] Rigidbody rbBullet;

    private float timer;


    void Start()
    {

        //Spawn with a velocity.

        rbBullet.linearVelocity = transform.right * -12f;

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
}
