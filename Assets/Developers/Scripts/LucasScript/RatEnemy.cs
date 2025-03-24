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
            velocityRat = 2f;
        }

        if (tfRat.position.x > 12f)
        {
            velocityRat = -2f;
        }
    }
}
