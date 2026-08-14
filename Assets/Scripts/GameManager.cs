using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int Wave { get; private set; } = 1;
    public float Score { get; private set; } = 0f;

    [SerializeField] private GameObject _plane;

    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
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
}
