using UnityEngine;

public class RailCannon : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWarn;

    [SerializeField] Transform laserPoint;

    private float laserTCD;
    private float laserTCDW;

    private bool laserFired = false;
    private bool laserFiredWarn = false;
    private bool laserDone = false;

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


        if (laserDone)
        {

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

        }

        if (laserTCD >= 5f)
        {
            if (!laserFired)
            {
                Instantiate(laser, laserPoint.position, laserPoint.rotation);

                laserFired = true;
            }
        
            if (warningLaser != null)
            {
                Destroy(warningLaser);
            }

            if (laserTCD >= 10f)
            {

                laserDone = true;

            }

        }


    }

}
