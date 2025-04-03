using UnityEngine;

public class WhaleBoss : MonoBehaviour
{
    [SerializeField] Transform tfWhale;
    [SerializeField] Rigidbody rbWhale;

    [SerializeField] GameObject laser;
    [SerializeField] GameObject laserWarn;

    [SerializeField] GameObject minigunB;

    [SerializeField] Transform laserPoint;
    [SerializeField] Transform laserPointWarn;

    [SerializeField] Transform minigun;

    private int laserA;
    private int laserAW;

    private float laserPZ;
    private float laserPZW;

    private float minigunPZ;

    private float laserTCD;
    private float laserTCDW;

    private int laserAmount = 10;

    private float minigunTCD;

    private float attackDeciderT;

    [SerializeField] float minigunC = 0.07f;

    [SerializeField] float minigunSU;

    private int turnAmount;

    private GameObject[] warningLasers = new GameObject[10];

    [SerializeField] enum AttackType { Laser, Minigun, None };

    [SerializeField] AttackType attackType;

    void Start()
    {
        turnAmount = Random.Range(13, 16);

        laserPZ = laserPoint.position.z;
        minigunPZ = minigun.position.z;
    }

    //void Update()
    //{
    //    if (attackType == AttackType.Laser)
    //    {

    //        tfWhale.position = new Vector3(tfWhale.position.x, -6f, tfWhale.position.z);
    //        RailCannonShoot();

    //    }

    //    else if (attackType == AttackType.Minigun)
    //    {

    //        tfWhale.position = new Vector3(tfWhale.position.x, 7f, tfWhale.position.z);
    //        MinigunShoot();

    //    }

    //    else
    //    {
    //        attackDeciderT += Time.deltaTime;

    //        tfWhale.position = new Vector3(tfWhale.position.x, 0f, tfWhale.position.z);

    //        if (attackDeciderT >= 2f)
    //        {
    //            DecideNextAttack();
    //            attackDeciderT = 0f;
    //        }

    //    }

    //}

    //private void DecideNextAttack()
    //{
    //    int random = Random.Range(0, 2);
    //    if (random <= 0)
    //    {
    //        attackType = AttackType.Laser;
    //    }

    //    else if (random >= 1)
    //    {
    //        attackType = AttackType.Minigun;
    //    }
    //    Debug.Log(random);
    //}

    private void MinigunShoot()
    {
        minigunTCD += Time.deltaTime;

        if (attackType != AttackType.Minigun)
        {
            minigunSU = 0;
            minigunC = 0.07f;
            minigunTCD = 0f;
        }

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
            attackType = AttackType.None;
        }
    }

    private void RailCannonShoot()
    {
        laserTCD += Time.deltaTime;
        laserTCDW += Time.deltaTime;

        if (attackType != AttackType.Laser)
        {
            laserTCD = 0f;
            laserTCDW = 0f;
            laserA = 0;
            laserAW = 0;
            turnAmount = Random.Range(13, 16);

        }

        if (laserAW >= laserAmount && laserA >= laserAmount)
        {
            laserTCD = 0;
            laserTCDW = 0;
            laserA = 0;
            laserAW = 0;
            turnAmount = Random.Range(5, 20);
            laserPointWarn.transform.rotation = Quaternion.Euler(new Vector3(laserPointWarn.transform.rotation.x, laserPointWarn.transform.rotation.y, laserPZW = 0f));
            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(laserPoint.transform.rotation.x, laserPoint.transform.rotation.y, laserPZ = 0f));
            attackType = AttackType.None;
        }

        if (laserTCDW >= 0.1f && laserAW <= laserAmount - 1)
        {
            GameObject warn = Instantiate(laserWarn, laserPointWarn.position, laserPointWarn.rotation);
            warningLasers[laserAW] = warn;
            laserPointWarn.transform.rotation = Quaternion.Euler(new Vector3(laserPointWarn.transform.rotation.x, laserPointWarn.transform.rotation.y, laserPZW -= turnAmount));
            laserAW++;
            laserTCDW = 0f;
        }

        if (laserTCD >= 0.2f && laserA <= laserAmount - 1 && laserAW >= 4)
        {
            Instantiate(laser, laserPoint.position, laserPoint.rotation);
            laserPoint.transform.rotation = Quaternion.Euler(new Vector3(laserPoint.transform.rotation.x, laserPoint.transform.rotation.y, laserPZ -= turnAmount));

            if (warningLasers[laserA] != null)
            {
                Destroy(warningLasers[laserA]);
            }

            laserA++;
            laserTCD = 0f;
        }

        
    }
}


