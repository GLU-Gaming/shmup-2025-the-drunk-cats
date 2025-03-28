using System.Threading;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.1f)
        {
            Destroy(gameObject);
        }
    

    }
}
