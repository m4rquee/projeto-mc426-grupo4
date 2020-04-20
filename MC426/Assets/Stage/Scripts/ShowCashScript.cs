using System.Collections;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShowCashScript : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    int scoreCounter;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = "Cash:" + SlimeCollector.cash.ToString();
    }
}