using Unity.VisualScripting;
using UnityEngine;

public class Minigun : MonoBehaviour
{

    private Transform player;

    private float minigunPZ;
    private float minigunTCD;

    [SerializeField] float minigunC = 0.07f;

    [SerializeField] float minigunSU;
    [SerializeField] GameObject minigunB;
    [SerializeField] Transform minigun;

    [SerializeField] float health = 20f;

    private Minigun minigunS;

    private RocketLauncher RocketLauncher;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        minigunS = GetComponent<Minigun>();

        RocketLauncher = FindAnyObjectByType<RocketLauncher>();


    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            MinigunShoot();
        }

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            minigunSU = 0;
            minigunC = 0.07f;
            minigunTCD = 0f;
        }
    }
    void Update()
    {

    }

    private void MinigunShoot()
    {
        minigunTCD += Time.deltaTime;

        if (minigunTCD >= minigunC)
        {

            minigunPZ = Random.Range(0, 90);
            minigun.transform.rotation = Quaternion.Euler(new Vector3(minigun.transform.rotation.x, minigun.transform.rotation.y, minigunPZ));
            Instantiate(minigunB, minigun.position, minigun.rotation);
            minigunTCD = 0f;
            minigunSU++;
        }
        if (minigunSU >= 15)
        {
            minigunC -= 0.01f;
            minigunSU = 0;
        }

        if (minigunC <= 0f)
        {
            minigunSU = 0;
            minigunC = 0.07f;
            minigunTCD = 0f;
        }
    }

    public void TakeDamageTwo()
    {
        health -= 1;
        if (health <= 0)
        {
            RocketLauncher.enabled = true;
            Destroy(minigunS);
        }
    }
}
