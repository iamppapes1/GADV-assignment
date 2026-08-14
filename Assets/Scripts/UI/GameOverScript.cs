using System;
using TMPro;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public static Action OnPlayerDeath;
    
    [SerializeField] private GameObject _restartFrame;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _waveText;

    void Awake()
    {
        OnPlayerDeath += GameOver;
    }

    void OnDestroy()
    {
        OnPlayerDeath -= GameOver;
    }

    void GameOver()
    {
        _restartFrame.SetActive(true);
        Time.timeScale = 0;
        var scoreTMP = _scoreText.GetComponent<TextMeshProUGUI>();
        var waveTMP = _waveText.GetComponent<TextMeshProUGUI>();

        scoreTMP.text = $"Score: {GameManager.Instance.Score}";
        waveTMP.text = $"Wave: {GameManager.Instance.Wave}";
    }
}
