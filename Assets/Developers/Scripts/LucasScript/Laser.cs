using System.Threading;
using UnityEngine;

public class Laser : MonoBehaviour
{

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
    

    }
}
