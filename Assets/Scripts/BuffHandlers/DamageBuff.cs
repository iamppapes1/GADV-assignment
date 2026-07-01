using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class DamageBuffGiver : MonoBehaviour
{
    private float _damageBuff = 10;
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
        _damageBuff = BuffValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit player");
            PlaneMain plane = other.GetComponent<PlaneMain>();
            plane.Upgrade("Damage", _damageBuff);
            Destroy(gameObject);
        }

    }
}
