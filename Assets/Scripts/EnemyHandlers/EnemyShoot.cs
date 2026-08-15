using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _enemyBullet;
    public GameObject _barrel;

    [SerializeField] private AudioSource _shootSound;
    
    void Start()
    {   
        Coroutine coroutine = StartCoroutine(Fire());
    }

    //Makes the enemy shoot. Fixed cooldown of 10 seconds as anything lower would cause the game to be unfair at later waves.
    IEnumerator Fire()
    {   
        yield return new WaitForSeconds(1);
        while (GameManager.Instance.State == GameState.Playing)
        {
            GameObject clone = Instantiate(
                _enemyBullet,
                _barrel.transform
            );
            clone.transform.parent = null;
            EnemyBullet bullet = clone.GetComponent<EnemyBullet>();
            bullet.Init(gameObject.GetComponent<Damage>().Get());
            _shootSound.Play();
            yield return new WaitForSeconds(10f);
        }
    }
}
