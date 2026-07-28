using UnityEngine;

public class Firerate : MonoBehaviour
{
    [SerializeField] private float _firerate = 0.5f;

    public void Upgrade()
    {
        _firerate *= 0.95f;
    }

    public float Get()
    {
        return _firerate;
    }
}
