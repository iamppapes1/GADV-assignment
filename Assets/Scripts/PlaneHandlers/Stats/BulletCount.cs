using UnityEngine;

public class BulletCount : MonoBehaviour
{
    [SerializeField] private int _bullets = 1;

    public void Upgrade()
    {
        if (_bullets < 5)
        {
            _bullets++;
        }
    }

    public int Get()
    {
        return _bullets;
    }
}
