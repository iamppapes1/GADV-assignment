using System;
using UnityEngine;

public class HealthUIUpdate : MonoBehaviour
{
    public static Action HealthChange;

    private RectTransform _rectTransform;
    [SerializeField] GameObject _plane;

    void Awake()
    {
        HealthChange += UpdateUI;
        _rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        Health _health = _plane.GetComponent<Health>();

        var scale = _health.GetHealth()/_health.GetMaxHealth();

        _rectTransform.localScale = new Vector3(scale, 1, 0);
    }
}
