using UnityEngine;
using System.Collections;
public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Barrel;
    private PlaneMain _plane;
    private EnemyMain _enemy;

    private string emitter;

    void Awake()
    {
        if (gameObject.CompareTag("Player"))
        {
            _plane = gameObject.GetComponent<PlaneMain>();
            emitter = "Player";
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            _enemy = gameObject.GetComponent<EnemyMain>();
            emitter = "Enemy";
        }
    }
    void Start()
    {   
        Coroutine coroutine = StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {   
        if (emitter == "Player")
        {
            while (true)
            {   
                //Debug.Log("Shoot");
                GameObject clone = Instantiate(
                    Bullet,
                    Barrel.transform
                );
                clone.transform.parent = null;
                Bullet bullet = clone.GetComponent<Bullet>();
                bullet.Init(_plane.GetDamage());
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            while (true)
            {   
                Debug.Log("Shoot");
                Debug.Log(Barrel.transform.position + " enemy barrel");
                GameObject clone = Instantiate(
                    Bullet,
                    Barrel.transform
                );
                clone.transform.parent = null;
                EnemyBullet bullet = clone.GetComponent<EnemyBullet>();
                bullet.Init(_enemy.GetDamage());
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
