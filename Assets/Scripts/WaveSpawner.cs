using UnityEngine;
using System.Collections;
using Unity.Mathematics;

public class WaveSpawner : MonoBehaviour
{
    private Vector2 _Min = new Vector2(-2.8f, 4f);
    private Vector2 _Max = new Vector2(2.8f, 4f);
    private GameObject[] _Enemies;

    [SerializeField] private AnimationCurve WaveDesign;

    private Coroutine Spawner;

    private int _aliveCount = 0;

    private bool _spawning = true;

    void Start()
    {
        /*Makes enemies scalable, auto add into the game when I add more enemies
        It also allows the use of another list to design the addition of more enemies into the spawn pool*/
        _Enemies = Resources.LoadAll<GameObject>("Prefabs/Enemies");
        Spawner =  StartCoroutine(SpawnEnemies());
    }

    /* Spawns enemies. The amount of enemies is determined by a AnimationCurv, 
    which also allows easy wave scaling of enemies to spawn.*/
    IEnumerator SpawnEnemies()
    {
        _spawning = true;
        var wave = GameManager.Instance.Wave;
        float evaluate = WaveDesign.Evaluate(wave);
        for (int i = 0; i <= math.round(evaluate); i++)
        {
            if (GameManager.Instance.State == GameState.Dead)
            {
                break;
            }
            
            float spawnLocation = UnityEngine.Random.Range(-2.8f, 2.8f);
            GameObject randomEnemy = _Enemies[UnityEngine.Random.Range(0, _Enemies.Length)];        

            GameObject Enemy = Instantiate(
                randomEnemy,
                new Vector2(spawnLocation, 4f),
                randomEnemy.transform.rotation
            );
            
            Enemy.GetComponent<Death>().OnEnemyDeath += DiedEvent;
            _aliveCount++;

            yield return new WaitForSeconds(0.5f);
        }
        
        _spawning = false;
        StopCoroutine(Spawner);
    }

    void DiedEvent(Death Instance)
    {
        Instance.OnEnemyDeath -= DiedEvent;
        _aliveCount--;
        if (_aliveCount <= 0 && !_spawning)
        {
            GameManager.Instance.NextWave();
            Spawner = StartCoroutine(SpawnEnemies());
        }
    }
}
