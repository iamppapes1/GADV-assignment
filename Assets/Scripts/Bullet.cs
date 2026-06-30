using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Damage = 10;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlaneMain plane = other.GetComponent<PlaneMain>();

        plane.TakeDamage(Damage);
    }
}
