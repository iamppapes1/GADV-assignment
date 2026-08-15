using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] _upgrades;

    private bool PlayerDead = false;

    [SerializeField] private AudioSource _deathSound;

    void Awake()
    {
        _upgrades = Resources.LoadAll<GameObject>("Prefabs/Upgrades");
    }

    void OnDestroy()
    {
        WaveSpawner.OnEnemyDeath.Invoke();
    }

    /*Checks if the gameObject the component is attached to is a enemy or player.
    If it's a player, send a event that tells the game that game is over and that the player lost
    If it's an enemy, 20% change that spawns an upgrade prefab
    Also fires 2 actions, one that tells the GameManager that an enemy died and we should add to the player's score
    and the other tells the WaveSpawner to deduct from the alive count so that it can spawn another wave when it's eventually 0*/
    public void OnDeath()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (UnityEngine.Random.value < 0.2f)
            {
                GameObject clone = Instantiate(_upgrades[UnityEngine.Random.Range(0, _upgrades.Length)],
                gameObject.transform.position,
                Quaternion.identity,
                null
                );
            }
            
            GameManager.Instance.AddScore(10);
            _deathSound.Play();
            AudioSource.PlayClipAtPoint(_deathSound.clip, transform.position);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Player"))
        {
            if (!PlayerDead)
            {
                _deathSound.Play();
                GameManager.Instance.SetState(GameState.Dead);
                GameOverScript.OnPlayerDeath.Invoke();
                PlayerDead = true;
            }
            
        }
    }
}
