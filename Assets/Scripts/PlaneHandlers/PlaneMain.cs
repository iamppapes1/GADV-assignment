using UnityEngine;

public class PlaneMain : MonoBehaviour
{
    // stats
    private float _damage = 10f;
    private float _health = 100f;

    void Awake()
    {
        Debug.Log($"Health: {_health}, Damage {_damage}");
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

    public void Upgrade(string type, float value)
    {
        if (type == "Damage")
        {
            _damage += value;
        }
    }

    public float GetDamage()
    {
        return _damage;
    }
}
