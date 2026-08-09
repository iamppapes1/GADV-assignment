using UnityEngine;
using System.Collections;

public class PlaneShoot : MonoBehaviour
{
    private GameObject[] _bullet;
    public GameObject _barrel;

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
        while (true)
        {   
            Debug.Log("Shoot");

            GameObject clone = Instantiate(
                _bullet[gameObject.GetComponent<BulletCount>().Get() - 1],
                _barrel.transform
            );
            clone.transform.parent = null;

            foreach (PlaneBullet bullet in clone.GetComponentsInChildren<PlaneBullet>())
            {
                bullet.Init(gameObject.GetComponent<Damage>().Get());
            }

            yield return new WaitForSeconds(gameObject.GetComponent<Firerate>().Get());
        }

    }
}
