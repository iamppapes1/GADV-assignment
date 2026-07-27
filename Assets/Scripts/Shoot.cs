using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    private GameObject[] _bullet;
    [SerializeField] private GameObject _enemyBullet;
    public GameObject _barrel;
    private PlaneMain _plane;
    private EnemyMain _enemy;

    private string emitter;

    void Awake()
    {
        _bullet = Resources.LoadAll<GameObject>("Prefabs/Bullets/Player");
    }
    void Start()
    {   
        Coroutine coroutine = StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {   
        if (gameObject.CompareTag("Player"))
        {
            _plane = gameObject.GetComponent<PlaneMain>();
            while (true)
            {   
                //Debug.Log("Shoot");

                Debug.Log(_bullet);

                GameObject clone = Instantiate(
                    _bullet[_plane._bullets - 1],
                    _barrel.transform
                );
                clone.transform.parent = null;

                foreach (Bullet bullet in clone.GetComponentsInChildren<Bullet>())
                {
                     bullet.Init(_plane._damage);
                }

                yield return new WaitForSeconds(_plane._firerate);
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {   
            _enemy = gameObject.GetComponent<EnemyMain>();
            while (true)
            {   
                Debug.Log("Shoot");
                Debug.Log(_barrel.transform.position + " enemy barrel");
                GameObject clone = Instantiate(
                    _enemyBullet,
                    _barrel.transform
                );
                clone.transform.parent = null;
                EnemyBullet bullet = clone.GetComponent<EnemyBullet>();
                bullet.Init(_enemy.GetDamage());
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
