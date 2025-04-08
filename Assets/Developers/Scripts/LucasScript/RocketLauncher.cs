using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    private Transform player;

    [SerializeField] GameObject rocekt;

    private float timer;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        ShootRocket();

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.1f)
        {
 
            ShootRocket();
            timer = 0f;
        }

    }


    private void ShootRocket()
    {

        Instantiate(rocekt, transform.position, transform.rotation);

    }
}
