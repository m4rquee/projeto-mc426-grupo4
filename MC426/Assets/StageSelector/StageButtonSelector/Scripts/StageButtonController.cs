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
        _text.text = "Fase " + (buttonIndex + 1).ToString("00");
        _currentImage.sprite = isButtonBlocked ? _disabledButtonSprite : _enabledButtonSprite;
        _button.onClick.AddListener(onClick);
    }

    public void UpdateSprite(bool isButtonBlocked)
    {
        _currentImage.sprite = isButtonBlocked ? _disabledButtonSprite : _enabledButtonSprite;
    }
}
