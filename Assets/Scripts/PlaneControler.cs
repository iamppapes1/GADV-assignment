using UnityEngine;

public class PlaneControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5f;
    private Vector2 direction = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            direction = Vector2.left;
            return;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            direction = Vector2.right;
            return;
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            direction = Vector2.up;
            return;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            direction = Vector2.down;
            return;
        }
        
        direction = Vector2.zero;
    }

    void FixedUpdate()
    {
        rb.AddForce(direction * speed);
    }
}
