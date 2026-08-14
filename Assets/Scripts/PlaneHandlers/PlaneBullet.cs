using System.Collections;
using UnityEngine;

public class PlaneBullet : MonoBehaviour
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
        _rb.AddForce(Vector2.up * 100);
    }

    public void Init(float damage)
    {
        _damage = damage;
    }

    /*Check if it's an enemy. If it is, get their health component
    and call the Damage method. Damage is taken from the plane's Damage component*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health enemyHealth = other.GetComponent<Health>();
            enemyHealth.Damage(_damage);
            Destroy(gameObject);
        }
    }
}
