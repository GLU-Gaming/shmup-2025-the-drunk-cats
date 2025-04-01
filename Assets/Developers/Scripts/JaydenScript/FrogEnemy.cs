using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class FrogEnemy : MonoBehaviour
{
    public GameObject frogTongue;
    public Transform frogBulletSpawn;
    public float scaleDuration = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnAndScaleTongue());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnAndScaleTongue()
    {
        while (true)
        {
            FrogEnemy frogEnemy = GetComponent<FrogEnemy>();
            frogEnemy.transform.up = Vector3.up;
            GameObject instantiatedTongue = Instantiate(frogTongue, frogBulletSpawn.position, frogBulletSpawn.rotation);
            StartCoroutine(ScaleTongue(instantiatedTongue, 10, scaleDuration));
            yield return new WaitForSeconds(5f);
        }
    }
    private IEnumerator ScaleTongue(GameObject tongue, float targetScaleX, float duration)
    {
        Vector3 initialScale = tongue.transform.localScale;
        Vector3 targetScale = new Vector3(targetScaleX, initialScale.y, initialScale.z);
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            tongue.transform.Translate(Vector3.right * -4 * Time.deltaTime);
            tongue.transform.localScale = Vector3.Lerp(initialScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        tongue.transform.localScale = targetScale;
        yield return new WaitForSeconds(1f);
        elapsedTime = 0;

        while (elapsedTime < duration)
        {
            tongue.transform.Translate(Vector3.right * 4 * Time.deltaTime);
            tongue.transform.localScale = Vector3.Lerp(targetScale, initialScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        tongue.transform.localScale = initialScale;
        Destroy(tongue);
    }
}
