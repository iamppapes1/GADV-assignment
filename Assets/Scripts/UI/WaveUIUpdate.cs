using System;
using TMPro;
using UnityEngine;

public class WaveUIUpdate : MonoBehaviour
{
    public static Action WaveChange;

    private TextMeshProUGUI _text;

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        WaveChange += UpdateUI;
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        var wave = GameManager.Instance.Wave;
        _text.text = "Wave: " + wave;
    }
}
