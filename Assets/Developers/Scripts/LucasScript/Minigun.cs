using UnityEngine;

public class Minigun : MonoBehaviour
{
    private Transform player;

    private float minigunPZ;
    private float minigunTCD;

    [SerializeField] float minigunC = 0.07f;

    [SerializeField] GameObject minigunModel;

    [SerializeField] float minigunSU;
    [SerializeField] GameObject minigunB;
    [SerializeField] Transform minigun;
    public AudioClip minigunSound;
    public AudioSource audiosource;

    [SerializeField] float health = 20f;

    private Minigun minigunS;

    private RocketLauncher RocketLauncher;

    private bool isSoundPlaying = false;

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
            audiosource.Stop();
            isSoundPlaying = false;
            minigunSU = 0;
            minigunC = 0.07f;
            minigunTCD = 0f;
        }
    }

    private void MinigunShoot()
    {
        minigunTCD += Time.deltaTime;

        if (minigunTCD >= minigunC)
        {
            if (!isSoundPlaying)
            {
                audiosource.PlayOneShot(minigunSound);
                isSoundPlaying = true;
            }

            minigunPZ = Random.Range(0, -90);
            minigun.transform.rotation = Quaternion.Euler(new Vector3(minigun.transform.rotation.x, minigun.transform.rotation.y, minigunPZ));
            Instantiate(minigunB, minigun.position, Quaternion.Euler(new Vector3(minigun.transform.rotation.x, minigun.transform.rotation.y, minigunPZ + 90)));
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
            isSoundPlaying = false;
        }
    }

    public void TakeDamageTwo()
    {
        health -= 1;
        if (health <= 0)
        {
            audiosource.Stop();
            RocketLauncher.enabled = true;
            Destroy(minigunModel);
            Destroy(minigunS);
        }
    }
}