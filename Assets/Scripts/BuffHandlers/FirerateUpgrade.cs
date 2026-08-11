using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class FirerateUpgrade : MonoBehaviour
{
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(Vector2.down * 10);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            other.GetComponent<Firerate>().Upgrade();
            Destroy(gameObject);
        }

    }
}
