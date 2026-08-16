using System.Threading.Tasks;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;

    [SerializeField] private AnimationCurve HealthScale;
    [SerializeField] private Sprite _damagedSprite;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    
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

    /*Damages the enemy/player. Whenever this method is called, tell the UI if any changes were made
    If the health drops below 0, get the Death component which handles enemy/player death.
    The sprite area is to add responsiveness to the game, to show that the bullet hit the enemy*/
    public async Task Damage(float value)
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

        var oldSprite = _spriteRenderer.sprite;
        if (_damagedSprite != null)
        {
            _spriteRenderer.sprite = _damagedSprite;
            await Awaitable.WaitForSecondsAsync(0.05f);
            _spriteRenderer.sprite = oldSprite;
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
