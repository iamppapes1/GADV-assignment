using UnityEngine;

public class PlaneMain : MonoBehaviour
{
    // stats
    [SerializeField] private float _damage;
    private float _health = 100;

    void Awake()
    {
        Debug.Log($"Health: {_health}, Damage {_damage}");
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Upgrade(int value)
    {
        
    }
}
