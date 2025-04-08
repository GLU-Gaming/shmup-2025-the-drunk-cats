using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

public class FrogEnemy : MonoBehaviour
{
    public GameObject frogTongue;
    public Transform frogBulletSpawn;
    public float healthFrog = 5;
    public float scaleDuration = 1f;
    public float moveSpeed = 5;

    public bool frogActivate;
    private SpawnEvilEnemies spawnManager;
    private Transform player;
    public GameObject frogEnemy;
    private Coroutine tongueCoroutine;
    private GameObject instantiatedTongue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnManager = FindFirstObjectByType<SpawnEvilEnemies>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        frogActivate = true;
        tongueCoroutine = StartCoroutine(SpawnAndScaleTongue());
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    private IEnumerator MoveFrog()
    {
        Vector3 targetPosition = new Vector3(Random.Range(3, 8), Random.Range(-3, 5), 0);
        float elapsedTime = 0;
        Vector3 startingPos = frogEnemy.transform.position;

        while (elapsedTime < moveSpeed)
        {
            frogEnemy.transform.position = Vector3.Lerp(startingPos, targetPosition, (elapsedTime / moveSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        frogEnemy.transform.position = targetPosition;
    }

    private IEnumerator SpawnAndScaleTongue()
    {
        while (true)
        {
            if (!frogActivate)
            {
                yield return new WaitForSeconds(3f);
                frogActivate = true;
                yield return new WaitUntil(() => frogActivate);
            }

            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            frogBulletSpawn.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));
            instantiatedTongue = Instantiate(frogTongue, frogBulletSpawn.position, frogBulletSpawn.rotation);
            StartCoroutine(ScaleTongue(instantiatedTongue, 14, scaleDuration));
            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator ScaleTongue(GameObject tongue, float targetScaleX, float duration)
    {
        FrogTongue frogTongueScript = tongue.GetComponent<FrogTongue>();
        Vector3 initialScale = tongue.transform.localScale;
        Vector3 targetScale = new Vector3(targetScaleX, initialScale.y, initialScale.z);
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            tongue.transform.Translate(Vector3.right * -14 * Time.deltaTime);
            tongue.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        tongue.transform.localScale = targetScale;
        yield return new WaitForSeconds(1f);
        elapsedTime = 0;

        while (elapsedTime < duration)
        {
            tongue.transform.Translate(Vector3.right * 14 * Time.deltaTime);
            tongue.transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        tongue.transform.localScale = initialScale;
        Destroy(tongue);
        yield return MoveFrog();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RemoveRat();
        }

        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            healthFrog--;
        }

        else if (collision.gameObject.CompareTag("PlayerSuperProjectile"))
        {
            RemoveRat();
        }
    }

    private void CheckHealth()
    {
        if (healthFrog <= 0)
        {
            RemoveRat();
        }
    }

    private void RemoveRat()
    {
        if (spawnManager != null)
        {
            spawnManager.RemoveEnemy(gameObject);
        }
        if (instantiatedTongue != null)
        {
            Destroy(instantiatedTongue);
        }
        Destroy(gameObject);
    }
}

