using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public int Wave { get; private set; } = 1;
    public float Score { get; private set; } = 0f;

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
    }

    public void NextWave()
    {
        Wave++;
    }
}
