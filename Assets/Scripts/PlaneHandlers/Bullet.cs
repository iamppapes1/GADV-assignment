using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage = 10;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(Vector2.up * 100);
    }

    public void Init(float damage)
    {
        _damage = damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            EnemyMain enemy = other.GetComponent<EnemyMain>();
            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
