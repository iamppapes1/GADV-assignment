using UnityEngine;

public class Firerate : MonoBehaviour
{
    [SerializeField] private float _firerate = 0.5f;

    public void Upgrade()
    {
        if (_firerate > 0.05f)
        {
            _firerate *= 0.9f;
        }
        if (_firerate < 0.05f)
        {
            _firerate = 0.05f;
        }
        StatUIUpdate.UpgradeEvent.Invoke();
    }

    public float Get()
    {
        return _firerate;
    }
}
