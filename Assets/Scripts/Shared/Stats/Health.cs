using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    private float _health = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _health = _maxHealth;
    }

    //Mainly for enemy spawning
    public void Init(float value)
    {
        _maxHealth = value;
        _health = _maxHealth;
    }

    public void Upgrade()
    {
        _maxHealth *= 1.05f;
        _health *= 1.05f;
    }

    public void Damage(float value)
    {
        _health -= value;

        if (_health <= 0)
        {
            gameObject.GetComponent<Death>().OnDeath();
        }
    }

    public void Heal(float value)
    {
        if (_health + value > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health += value;
        }
    }

    public float GetHealth()
    {
        return _health;
    }

    public float GetMaxHealth()
    {
        return _maxHealth;
    }
}
