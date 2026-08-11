using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] float _speed = 5f;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(Vector2.down * _speed);
    }
}
