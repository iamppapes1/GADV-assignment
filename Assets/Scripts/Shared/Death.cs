using System;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] _upgrades;
    public event Action<Death> OnEnemyDeath;

    void Awake()
    {
        _upgrades = Resources.LoadAll<GameObject>("Prefabs/Upgrades");
    }
    public void OnDeath()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (UnityEngine.Random.value < 0.2f)
            {
                GameObject clone = Instantiate(_upgrades[UnityEngine.Random.Range(0, _upgrades.Length)],
                gameObject.transform
                );
                clone.transform.parent = null;
            }
            
            GameManager.Instance.AddScore(10);
            OnEnemyDeath.Invoke(this);
        }

         Destroy(gameObject);
    }
}
