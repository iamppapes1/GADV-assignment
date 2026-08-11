using System;
using TMPro;
using UnityEngine;

public class ScoreUIUpdate : MonoBehaviour
{
    public static Action ScoreChange;

    private TextMeshProUGUI _text;

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        ScoreChange += UpdateUI;
    }

    void UpdateUI()
    {
        var score = GameManager.Instance.Score;
        _text.text = "Score: " + score;
    }
}
