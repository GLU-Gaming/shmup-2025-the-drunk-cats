using UnityEngine;

public class FrogTongue : MonoBehaviour
{
    [SerializeField] FrogEnemy frogEnemy;
    public GameObject frogTongue;
    public bool isHit = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        frogEnemy = FindFirstObjectByType<FrogEnemy>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            isHit = true;
            Destroy(collision.gameObject); 
            frogEnemy.frogActivate = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
