using UnityEngine;

public class PlaneMain : MonoBehaviour
{
    // stats
    private float _damage = 10f;
    private float _maxhealth = 100f;
    private float _health = 0f;

    void Awake()
    {
        Debug.Log($"Health: {_health}, Damage {_damage}");
        Init();
    }

    private void Init()
    {
        _health = _maxhealth;

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
            Debug.Log($"Damage is now at {_damage}");
        }
        else if (type == "Health")
        {
            _maxhealth += value;
            Debug.Log($"health is now at {_maxhealth}");
        }
    }

    public float GetDamage()
    {
        return _damage;
    }
}
