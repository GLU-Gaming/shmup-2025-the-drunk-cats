using UnityEngine;

public class RatEnemy : MonoBehaviour
{

    [SerializeField] Rigidbody rbRat;
    [SerializeField] Transform tfRat;
    [SerializeField] float speedRat;
    private float velocityRat;
    private RatState currentRatState;
    private enum RatState { Up, Down};
    private float timerRat;
    private float healthRat = 3f;
    void Start()
    {
        currentRatState = RatState.Up;

        velocityRat = -2f;

        ChangeHeight();

    }

    void Update()
    {

        DecideHeight();

        ChangeDirection();

        DestroyOnHeight();

        CheckHealth();

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            healthRat -= 1f;
        }

        else if (collision.gameObject.CompareTag("PlayerSuperProjectile"))
        {
            Destroy(gameObject);
        }

    }

    private void ChangeHeight()
    {

        rbRat.linearVelocity = (transform.up * (speedRat * 3f)) + (transform.right * velocityRat);
        
    }

    private void DecideHeight()
    {

        if (currentRatState == RatState.Up)
        {
            speedRat += Time.deltaTime;

            ChangeHeight();
            if (speedRat >= 1.1f)
            {
                currentRatState = RatState.Down;
            }

        }
        else if (currentRatState == RatState.Down)
        {
            speedRat -= Time.deltaTime;

            ChangeHeight();
            if (speedRat <= -1f)
            {
                currentRatState = RatState.Up;
            }
        }

    }

    private void ChangeDirection()
    {
        
        if (tfRat.position.x < -12f)
        {
            velocityRat = 10f;
        }

        if (tfRat.position.x > 12f)
        {
            velocityRat = -2f;
        }
    }

    private void DestroyOnHeight()
    {
        if (tfRat.position.y >= 10f)
        {
            Destroy(gameObject);
        }
    }

    private void CheckHealth()
    {

        if (healthRat <= 0)
        {
            Destroy(gameObject);
        }

    }


}
