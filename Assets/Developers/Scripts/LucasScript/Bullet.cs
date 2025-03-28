using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 4f)
        {
            Destroy(gameObject);
        }
    }
}
