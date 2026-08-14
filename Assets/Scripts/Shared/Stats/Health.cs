using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    [SerializeField] private AnimationCurve HealthScale;
    
    private float _health = 0f;

    void Awake()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            var wave = GameManager.Instance.Wave;
            Init(HealthScale.Evaluate(wave));
        }
        else if (gameObject.CompareTag("Player"))
        {
            _health = _maxHealth;
        }
    }

    //Mainly for enemy spawning
    public void Init(float value)
    {
        _maxHealth = value;
        _health = _maxHealth;
    }

    public void Upgrade()
    {
        _maxHealth *= 1.1f;
        _health *= 1.1f;
        
        if (gameObject.CompareTag("Player"))
        {
            StatUIUpdate.UpgradeEvent.Invoke();
            HealthUIUpdate.HealthChange.Invoke();
        }
    }

    public void Damage(float value)
    {
        _health -= value;

        if (gameObject.CompareTag("Player"))
        {
            HealthUIUpdate.HealthChange.Invoke();
        }

        if (_health <= 0)
        {
            gameObject.GetComponent<Death>().OnDeath();
        }
    }

    public void Heal()
    {
        if (_health * 1.1f > _maxHealth)
        {
            _health = _maxHealth;
        }
        else
        {
            _health *= 1.1f;
        }

        if (gameObject.CompareTag("Player"))
        {
            HealthUIUpdate.HealthChange.Invoke();
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
