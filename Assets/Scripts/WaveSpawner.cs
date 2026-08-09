using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    private Vector2 _Min = new Vector2(-2.8f, 4f);
    private Vector2 _Max = new Vector2(2.8f, 4f);
    private GameObject[] _Enemies;

    private Coroutine Spawner;

    void Start()
    {
        _Enemies = Resources.LoadAll<GameObject>("Prefabs/Enemies");
        Spawner =  StartCoroutine(SpawnEnemies());
        StopCoroutine(Spawner);
    }

    // Update is called once per frame
    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnLocation = Random.Range(-2.8f, 2.8f);
            GameObject randomEnemy = _Enemies[Random.Range(0, _Enemies.Length - 1)];

            GameObject Enemy = Instantiate(
                randomEnemy,
                new Vector2(spawnLocation, 4f),
                randomEnemy.transform.rotation
            );

            Debug.Log("Spawned");

            yield return new WaitForSeconds(1);
        }
    }
}
