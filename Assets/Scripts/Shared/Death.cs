using System;
using UnityEngine;

public class Death : MonoBehaviour
{
    private GameObject[] _upgrades;
    public event Action<Death> OnEnemyDeath;

    private bool PlayerDead = false;

    void Awake()
    {
        _upgrades = Resources.LoadAll<GameObject>("Prefabs/Upgrades");
    }

    /*Checks if the gameObject the component is attached to is a enemy or player.
    If it's a player, send a event that tells the game that game is over and that the player lost
    If it's an enemy, 20% change that spawns an upgrade prefab*/
    public void OnDeath()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            if (UnityEngine.Random.value < 0.2f)
            {
                GameObject clone = Instantiate(_upgrades[UnityEngine.Random.Range(0, _upgrades.Length)],
                gameObject.transform
                );
                clone.transform.parent = null;
            }
            
            GameManager.Instance.AddScore(10);
            OnEnemyDeath.Invoke(this);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Player"))
        {
            if (!PlayerDead)
            {
                GameManager.Instance.SetState(GameState.Dead);
                GameOverScript.OnPlayerDeath.Invoke();
                PlayerDead = true;
            }
            
        }
    }
}
