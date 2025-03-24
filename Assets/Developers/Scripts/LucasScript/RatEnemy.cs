using UnityEngine;

public class RatEnemy : MonoBehaviour
{

    [SerializeField] Rigidbody rbRat;
    [SerializeField] Transform tfRat;
    [SerializeField] float speedRat;
    [SerializeField] Transform positionRat;
    private float velocityRat;
    private RatState currentRatState;
    private enum RatState { Up, Down};
    private float timerRat;
    void Start()
    {
        currentRatState = RatState.Up;

        velocityRat = -0.5f;

        ChangeHeight();

    }

    void Update()
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

    private void ChangeHeight()
    {

        rbRat.linearVelocity = (transform.up * (speedRat * 3f)) + (transform.right * velocityRat);
        
    }
}
