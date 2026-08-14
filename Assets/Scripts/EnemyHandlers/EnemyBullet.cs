using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EnemyBullet : MonoBehaviour
{
    private float _damage = 10;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Depsawn());
    }

    IEnumerator Depsawn()
    {
        yield return new WaitForSeconds(30);
        Destroy(gameObject);
    }
    void Start()
    {
        _rb.AddForce(Vector2.down * 50);
    }

    public void Init(float damage)
    {
        _damage = damage;
    }

    /*Check if it's the player. If it is, get their health component
    and call the Damage method. Damage is taken from the enemy's Damage component,
    which is scaled with a AnimationCurve*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Health>().Damage(_damage);
            Destroy(gameObject);
        }
        
    }
}
