using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    [SerializeField] private float timeAlive = 5f;
    protected GameManager game;

    private void Awake()
    {
        game = FindFirstObjectByType<GameManager>();
    }

    private void Update()
    {
        timeAlive -= Time.deltaTime;
        if (timeAlive <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Activate()
    {
        Destroy(gameObject);
    }

    public void SetTimeAlive(float time)
    {
        timeAlive = time;
    }
}