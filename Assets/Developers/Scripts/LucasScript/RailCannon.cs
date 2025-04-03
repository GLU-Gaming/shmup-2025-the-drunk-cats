using UnityEngine;

public class RailCannon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWarn;

    [SerializeField] Transform laserPoint;

    private float laserTCD;
    private float laserTCDW;

    private float laserFiredTCD;

    private bool laserFired = false;
    private bool laserFiredWarn = false;

    private GameObject warningLaser;

    private Transform player;


    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }


    private void OnTriggerStay(Collider other)
    {

        RailCannonShoot();

    }
    private void RailCannonShoot()
    {
        laserTCD += Time.deltaTime;
        laserTCDW += Time.deltaTime;


        if (laserFired)
        {
            laserFiredTCD += Time.deltaTime;

            laserTCD = 0;
            laserTCDW = 0;

            if (laserFiredTCD >= 5f)
            {
                laserFired = false;
                laserFiredWarn = false;
                laserFiredTCD = 0;
            }
            
        }

        if (laserTCDW >= 0.1f)
        {
            if (!laserFiredWarn)
            {
                GameObject warn = Instantiate(laser, laserPoint.position, laserPoint.rotation);
                warningLaser = warn;
                laserFiredWarn  = true;
            }

            Vector3 direction = player.position - laserPoint.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
        }

        if (laserTCD >= 5f)
        {
            Instantiate(laser, laserPoint.position, laserPoint.rotation);

            Vector3 direction = player.position - laserPoint.transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

            if (warningLaser != null)
            {
                Destroy(warningLaser);
            }

            if (laserFiredTCD >= 3f)
            {

                laserFired = true;

            }

        }


    }

}
