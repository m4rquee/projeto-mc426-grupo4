using System;
using UnityEngine;
using UnityEngine.UI;

public class SlimeCollector : MonoBehaviour
{
    [SerializeField] private int cashValue;
    [SerializeField] private Button _button;
    public static int Cash = 100;

    private void Start()
    {
        _button.onClick.AddListener(GiveCash);
    }

    private void GiveCash()
    {
        Cash += cashValue;
        Destroy(gameObject);
    }
}