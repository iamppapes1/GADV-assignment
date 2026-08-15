using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlaneShoot : MonoBehaviour
{
    private GameObject[] _bullet;
    public GameObject _barrel;

    [SerializeField] private AudioSource _shootSound;

    void Awake()
    {
        _bullet = Resources.LoadAll<GameObject>("Prefabs/Bullets/Player");
    }
    void Start()
    {   
        Coroutine coroutine = StartCoroutine(Fire());
    }

    /*Makes the plane shoot. The cooldown is determined by the firerate component on the plane.
    the bullets variable is there so I can make the plane shoot more bullets by using 5 prefabs instead of
    using complex math to calculate where bullets should be placed*/
    IEnumerator Fire()
    {   
        while (GameManager.Instance.State == GameState.Playing)
        {   
            GameObject clone = Instantiate(
                _bullet[gameObject.GetComponent<BulletCount>().Get() - 1],
                _barrel.transform
            );
            clone.transform.parent = null;

            foreach (PlaneBullet bullet in clone.GetComponentsInChildren<PlaneBullet>())
            {
                bullet.Init(gameObject.GetComponent<Damage>().Get());
            }

            _shootSound.Play();

            yield return new WaitForSeconds(gameObject.GetComponent<Firerate>().Get());
        }

    }
}
