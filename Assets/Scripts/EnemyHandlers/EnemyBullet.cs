using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float _damage = 10;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.AddForce(Vector2.down * 10);
    }

    public void Init(float damage)
    {
        _damage = damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Hit player {other}");
            other.GetComponent<Health>().Damage(_damage);
            Destroy(gameObject);
        }
        
    }
}
