using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class HealthUpgrade : MonoBehaviour
{
    private Rigidbody2D _rb;

    //Gets the RigidBody2D component to give it a downward force
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(Vector2.down * 10);
    }

    //When collided with plane, get its respective component with the upgrade type, call the Upgrade method within the component
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            other.GetComponent<Health>().Upgrade();
            Destroy(gameObject);
        }

    }
}
