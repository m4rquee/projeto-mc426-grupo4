using UnityEngine;
using TMPro;

public class ShowCashScript : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreCounter;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = BuildMenu.Cash.ToString();
    }
}