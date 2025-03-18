using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    private float moveY;
    private float moveX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveX = 0f;
        moveY = 0f;

        if (Input.GetKey(KeyCode.W)) moveY += 1;
        if (Input.GetKey(KeyCode.S)) moveY -= 1;
        if (Input.GetKey(KeyCode.A)) moveX -= 1;
        if (Input.GetKey(KeyCode.D)) moveX += 1;

        Vector3 moveDirection = new Vector3(moveX, moveY, 0).normalized;
        transform.position += moveDirection * speed * Time.deltaTime;
    }
}
