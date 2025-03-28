using UnityEngine;

public class LaserWarn : MonoBehaviour
{
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1.6f)
        {
            Destroy(gameObject);
        }


    }
}
