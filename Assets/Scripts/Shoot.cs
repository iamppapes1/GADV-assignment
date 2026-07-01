using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Bullet;
    public GameObject _barrel;
    private PlaneMain plane;

    void Awake()
    {
        plane = gameObject.GetComponent<PlaneMain>();
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
                Bullet,
                _barrel.transform
            );

            Bullet bullet = clone.GetComponent<Bullet>();
            bullet.Init(plane.GetDamage());
            yield return new WaitForSeconds(1f);
        }
        
    }
}
