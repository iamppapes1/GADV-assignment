using UnityEngine;

public class Firerate : MonoBehaviour
{
    [SerializeField] private float _firerate = 0.5f;

    public void Upgrade()
    {
        if (_firerate > 0.05f)
        {
            _firerate *= 0.95f;
        }
        if (_firerate < 0.05f)
        {
            _firerate = 0.05f;
        }
            
    }

    public float Get()
    {
        return _firerate;
    }
}
