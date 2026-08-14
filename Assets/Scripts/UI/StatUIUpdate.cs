using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class StatUIUpdate : MonoBehaviour
{
    public static Action UpgradeEvent;

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private GameObject _plane;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        UpgradeEvent += UpdateUI;
    }

    void OnDestroy()
    {
        UpgradeEvent -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    //Whenever any of the stat upgrades, update the UI to display the updated stats.
    private void UpdateUI()
    {
        _text.text = $"Stats:\nMax Health: {_plane.GetComponent<Health>().GetMaxHealth()}\nDamage: {_plane.GetComponent<Damage>().Get()}\nFirerate: {60/_plane.GetComponent<Firerate>().Get()} RP/M\nBullets: {_plane.GetComponent<BulletCount>().Get()}";
    }
}
