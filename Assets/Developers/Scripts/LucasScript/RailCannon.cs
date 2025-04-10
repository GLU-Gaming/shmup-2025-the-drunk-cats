using UnityEngine;

public class RailCannon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWarn;

    [SerializeField] GameObject laserModel;

    [SerializeField] Transform laserPoint;

    private float laserTCD;
    private float laserTCDW;

    private bool laserFired = false;
    private bool laserFiredOFR = false;
    private bool laserFiredWarn = false;
    private bool laserDone = false;

    private GameObject warningLaser;
    private GameObject laserShoot;

    private Transform player;

    [SerializeField] float health = 20f;

    private RocketLauncher rocketLauncher;

    private RailCannon railCannon;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rocketLauncher = FindAnyObjectByType<RocketLauncher>();
        railCannon = FindAnyObjectByType<RailCannon>();

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            RailCannonShoot();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !laserFired)
        {
            laserDone = true;
            Destroy(laserShoot);
            Destroy(warningLaser);
        }

        else if (other.CompareTag("Player") && laserFired)
        {
            laserFiredOFR = true;
            Destroy(warningLaser);
        }
    }

    private void Update()
    {
        if (laserFiredOFR)
        {
            RailCannonShoot();
        }

      

    }
    private void RailCannonShoot()
    {
        laserTCD += Time.deltaTime;
        laserTCDW += Time.deltaTime;


        if (laserDone)
        {

                laserFiredOFR = false;
                laserDone = false;
                laserFired = false;
                laserFiredWarn = false;
                laserTCD = 0;
                laserTCDW = 0;  
            
        }

        if (laserTCDW >= 0.1f)
        {
            if (!laserFiredWarn)
            {
                GameObject warn = Instantiate(laserWarn, laserPoint.position, laserPoint.rotation);
                warningLaser = warn;
                laserFiredWarn  = true;
            }

            Vector3 direction = player.position - laserPoint.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (laserTCD <= 1.7f && warningLaser != null)
            {
                laserPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));

                warningLaser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

            }

            if (laserTCD <= 3f && warningLaser != null)
            {
                warningLaser.transform.position = new Vector3(laserPoint.position.x, laserPoint.position.y, laserPoint.position.z);
            }

        }

        if (laserTCD >= 3f)
        {
            if (!laserFired)
            {
                GameObject warn = Instantiate(laser, laserPoint.position, warningLaser.transform.rotation);
                laserShoot = warn;

                laserFired = true;
            }
        
            if (warningLaser != null)
            {
                Destroy(warningLaser);
            }

            if (laserTCD <= 7.2f && laserShoot != null)
            {
                laserShoot.transform.position = new Vector3(laserPoint.position.x, laserPoint.position.y, laserPoint.position.z);

            }

            if (laserTCD >= 7.2f && laserShoot != null)
            {
                Destroy(laserShoot);
                laserDone = true;

            }

        }


    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            if (rocketLauncher != null)
            {
                rocketLauncher.enabled = true;
            }
            Destroy(laserShoot);
            Destroy(warningLaser);
            Destroy(laserModel);
            Destroy(railCannon);
        }
    }

}
