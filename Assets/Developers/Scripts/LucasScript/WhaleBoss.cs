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
        laserTCD += Time.deltaTime;
        laserTCDW += Time.deltaTime;

        if (laserTCDW >= 0.24f && laserAW <= 9)
        {
            GameObject warn = Instantiate(laserWarn, laserPointWarn.position, laserPointWarn.rotation);
            warningLasers[laserAW] = warn;
            laserPointWarn.transform.rotation = Quaternion.Euler(new Vector3(laserPointWarn.transform.rotation.x, laserPointWarn.transform.rotation.y, laserPZW -= 10f));
            laserAW++;
            laserTCDW = 0f;
        }

        if (laserTCD >= 0.36f && laserA <= 9 && laserAW >= 9)
        {
            Instantiate(laser, laserPoint.position, laserPoint.rotation);
            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(laserPoint.transform.rotation.x, laserPoint.transform.rotation.y, laserPZ -= 10f));

            if (warningLasers[laserA] != null) 
            {
                Destroy(warningLasers[laserA], 0.1f); 
            }

            laserA++;
            laserTCD = 0f;
        }
    }
}
