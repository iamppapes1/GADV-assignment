using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] _upgrades;

    void Awake()
    {
        _upgrades = Resources.LoadAll<GameObject>("Prefabs/Upgrades");
    }
    public void OnDeath()
    {
        Debug.Log($"dieded {gameObject.tag}");

        if (gameObject.CompareTag("Enemy"))
        {
            GameObject clone = Instantiate(_upgrades[Random.Range(1,_upgrades.Length)],
            gameObject.transform
            );
            clone.transform.parent = null;
        }

         Destroy(gameObject);
    }
}
