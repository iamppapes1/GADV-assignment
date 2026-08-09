using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _enemyBullet;
    public GameObject _barrel;
    
    void Start()
    {   
        Coroutine coroutine = StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {   
        while (true)
        {   
            GameObject clone = Instantiate(
                _enemyBullet,
                _barrel.transform
            );
            clone.transform.parent = null;
            EnemyBullet bullet = clone.GetComponent<EnemyBullet>();
            bullet.Init(gameObject.GetComponent<Damage>().Get());
            yield return new WaitForSeconds(5f);
        }
    }
}
