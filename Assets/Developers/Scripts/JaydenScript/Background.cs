using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    float leftScreenBorder;
    Renderer[] renderers;
    float totalWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftScreenBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in renderers)
        {
            totalWidth += renderer.bounds.size.x + 70;   
        }
    }

    // Update is called once per frame
    void Update()
    {
        float dir = -1;
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);

        foreach (Renderer renderer in renderers)
        {
            if (renderer.transform.position.x < leftScreenBorder - renderer.bounds.size.x)
            {
                renderer.transform.position += new Vector3(totalWidth, 0, 0);
            }
        }
    }


}

