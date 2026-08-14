using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    [SerializeField] private AnimationCurve DamageScale;

    void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            var wave = GameManager.Instance.Wave;
            Init(DamageScale.Evaluate(wave));
        }
    }

    //Mainly for enemy spawning
    public void Init(float value)
    {
        _damage = value;
    }

    public void Upgrade()
    {
        _damage *= 1.10f;
        StatUIUpdate.UpgradeEvent.Invoke();
    }

    public float Get()
    {
        return _damage;
    }
}
