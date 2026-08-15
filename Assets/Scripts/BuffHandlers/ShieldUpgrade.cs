using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class ShieldUpgrade : MonoBehaviour
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

    //When collided with plane, sets the shield to active as it's inactive in the game scene
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var shield = other.gameObject.transform.Find("Shield");

            if (shield != null)
            {
                shield.gameObject.SetActive(true);
            }

            Destroy(gameObject);
        }

    }
}
