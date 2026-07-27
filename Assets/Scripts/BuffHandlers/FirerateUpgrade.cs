using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class FirerateUpgrade : MonoBehaviour
{
    private float _value = 0.05f;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(Vector2.down * 10);
    }

    public void Init(float BuffValue)
    {
        _value = BuffValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            PlaneMain plane = other.GetComponent<PlaneMain>();
            plane.Upgrade("Firerate", _value);
            Destroy(gameObject);
        }

    }
}
