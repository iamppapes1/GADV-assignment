using UnityEngine;
using System;
using System.Collections;

public enum GameState
{
    Playing,
    Dead
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int Wave { get; private set; } = 1;
    public float Score { get; private set; } = 0f;

    public GameState State { get; private set; } = GameState.Playing;

    [SerializeField] private GameObject _plane;

    /*To reference the current instance that is within the scene.
    Prevents any duping of this class and to prevent data not deleting, especially when the scene reloads*/
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        StartCoroutine(RunTimeScore());
    }

    IEnumerator RunTimeScore()
    {
        while (State == GameState.Playing)
        {
            yield return new WaitForSeconds(0.1f);
            AddScore(1);
        }
        
    }

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreUIUpdate.ScoreChange.Invoke();
    }

    public void NextWave()
    {
        Wave++;
        _plane.GetComponent<Health>().Heal();
        WaveUIUpdate.WaveChange.Invoke();
    }

    public void SetState(GameState state)
    {
        State = state;
    }
}
