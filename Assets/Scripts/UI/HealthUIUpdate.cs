using System;
using UnityEngine;

public class HealthUIUpdate : MonoBehaviour
{
    public static Action HealthChange;

    private RectTransform _rectTransform;
    private float _old = 0f;
    [SerializeField] private GameObject _plane;
    [SerializeField] private AudioSource _damageSound;

    void Awake()
    {
        HealthChange += UpdateUI;
        _rectTransform = GetComponent<RectTransform>();
    }

    void OnDestroy()
    {
        HealthChange -= UpdateUI;
    }

    void Start()
    {
        UpdateUI();
    }

    /*Change the scale of the health bar (the green one) by the scale calculated by the plane's health/max health.
     If the scale is below 0, set it to 0 so it doesn't look like the UI broke. */
    void UpdateUI()
    {
        Health _health = _plane.GetComponent<Health>();

        var scale = _health.GetHealth()/_health.GetMaxHealth();

        if (scale < 0)
        {
            scale = 0;
        }

        if (scale < _old)
        {
            _damageSound.Play();
        }

        _old = scale;

        _rectTransform.localScale = new Vector3(scale, 1, 0);
    }
}
