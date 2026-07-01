using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    private float _health = 100f;
    private float _damage = 10f;

    public void Init(float health, float damage)
    {
        _health = health;
        _damage = damage;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
