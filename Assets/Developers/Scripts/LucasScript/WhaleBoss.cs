using System.Runtime.CompilerServices;
using UnityEngine;

public class WhaleBoss : MonoBehaviour
{
    [SerializeField] Transform tfWhale;
    [SerializeField] Rigidbody rbWhale;

    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWarn;

    [SerializeField] Transform laserPoint;
    [SerializeField] Transform laserPointWarn;

    private int laserA;
    private int laserAW;

    private float laserPZ;
    private float laserPZW;

    private float laserTCD;
    private float laserTCDW;

    private GameObject[] warningLasers = new GameObject[10]; 

    void Start()
    {
        laserPZ = laserPoint.position.z;
        laserPZW = laserPointWarn.position.z;
    }

    void Update()
    {
     CannonShoot();

    }

    private void CannonShoot()
    {
        laserTCD += Time.deltaTime;
        laserTCDW += Time.deltaTime;

        if (laserAW >= 6 && laserA >= 6)
        {
            laserTCD = 0;
            laserTCDW = 0;
            laserA = 0;
            laserAW = 0;
            laserPointWarn.transform.rotation = Quaternion.Euler(new Vector3(laserPointWarn.transform.rotation.x, laserPointWarn.transform.rotation.y, laserPZW = 0f));
            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(laserPoint.transform.rotation.x, laserPoint.transform.rotation.y, laserPZ = 0f));
        }

        if (laserTCDW >= 0.2f && laserAW <= 5)
        {
            GameObject warn = Instantiate(laserWarn, laserPointWarn.position, laserPointWarn.rotation);
            warningLasers[laserAW] = warn;
            laserPointWarn.transform.rotation = Quaternion.Euler(new Vector3(laserPointWarn.transform.rotation.x, laserPointWarn.transform.rotation.y, laserPZW -= 15f));
            laserAW++;
            laserTCDW = 0f;
        }

        if (laserTCD >= 0.4f && laserA <= 5 && laserAW >= 4)
        {
            Instantiate(laser, laserPoint.position, laserPoint.rotation);
            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(laserPoint.transform.rotation.x, laserPoint.transform.rotation.y, laserPZ -= 15f));

            if (warningLasers[laserA] != null)
            {
                Destroy(warningLasers[laserA]);
            }

            laserA++;
            laserTCD = 0f;
        }

        
    }
}


