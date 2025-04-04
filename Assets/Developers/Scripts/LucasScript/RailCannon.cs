using UnityEngine;

public class RailCannon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWarn;

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


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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

            if (laserTCD <= 3.7f && warningLaser != null)
            {
                laserPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

                warningLaser.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

            }

            if (laserTCD <= 5f && warningLaser != null)
            {
                warningLaser.transform.position = new Vector3(laserPoint.position.x, laserPoint.position.y, laserPoint.position.z);
            }

        }

        if (laserTCD >= 5f)
        {
            if (!laserFired)
            {
                GameObject warn = Instantiate(laser, laserPoint.position, laserPoint.rotation);
                laserShoot = warn;

                laserFired = true;
            }
        
            if (warningLaser != null)
            {
                Destroy(warningLaser);
            }

            if (laserTCD <= 9.2f && laserShoot != null)
            {
                laserShoot.transform.position = new Vector3(laserPoint.position.x, laserPoint.position.y, laserPoint.position.z);

            }

            if (laserTCD >= 9.2f && laserShoot != null)
            {
                Destroy(laserShoot);
                laserDone = true;

            }

        }


    }

}
