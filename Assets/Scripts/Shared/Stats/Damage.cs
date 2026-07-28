using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float _damage = 10f;

    public void Upgrade()
    {
        _damage *= 1.10f;
    }

    public float Get()
    {
        return _damage;
    }
}
