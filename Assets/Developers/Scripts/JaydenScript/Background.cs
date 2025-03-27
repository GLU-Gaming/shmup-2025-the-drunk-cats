using UnityEngine;

public class Background : MonoBehaviour
{
    
    [SerializeField] float speed = 1.0f;
    Vector3 startPos;
    Vector3 leftScreenBorder;
    Vector3 screenBounds;
    Renderer currentRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Start pos initialiseren
        startPos = transform.position;
        //leftScreenBorder = Camera.main.ViewportToWorldPoint(new Vector3(5, 0, 0));
        screenBounds = Camera.main.ScreenToWorldPoint(Vector3.zero);
        
        currentRenderer = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        float dir = -1;
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x < leftScreenBorder.x)
        {
            Debug.Log("Resetting!");
            transform.position = startPos;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(leftScreenBorder, new Vector3(20, 0, 10));
    }
}
