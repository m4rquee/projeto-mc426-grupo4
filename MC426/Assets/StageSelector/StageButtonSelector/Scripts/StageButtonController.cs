using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StageButtonController : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Sprite _enabledButtonSprite;
    [SerializeField] private Sprite _disabledButtonSprite;
    [SerializeField] private Image _currentImage;

    public void Init(int buttonIndex, bool isButtonBlocked, UnityAction onClick)
    {
        _text.text = CreateStageName(buttonIndex);
        _currentImage.sprite = isButtonBlocked ? _disabledButtonSprite : _enabledButtonSprite;
        _button.onClick.AddListener(onClick);
    }

    string CreateStageName(int index)
    {
        return $"Fase {(index + 1):00}";
    }
}
