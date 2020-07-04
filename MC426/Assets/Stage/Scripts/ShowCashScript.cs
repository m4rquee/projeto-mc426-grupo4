using UnityEngine;
using TMPro;

public class ShowCashScript : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreCounter;

    public string GetText()
    {
        return scoreText.text;
    }

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        scoreText.text = BuildMenu.Cash.ToString();
    }
}