using Common.Broadcaster;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerButtonController : MonoBehaviour, IMessageSubscriber<TowerPlacedMessage>, IMessageSubscriber<TowerSelectedMessage>
{
    [SerializeField] private TextMeshProUGUI _moneyAmount;
    [SerializeField] private Button _button;
    [SerializeField] private Image _towerImage;
    [SerializeField] private Image _backgroundHighlight;

    private UnityAction _onClick;

    public void Setup(TowerInfo towerInfo, UnityAction onClick)
    {
        _moneyAmount.text = towerInfo.Price.ToString();
        _towerImage.sprite = towerInfo.PreviewImage;
        _onClick = onClick;
        _button.onClick.AddListener(OnTowerButtonClick);
        MessageBroadcaster.Instance.Subscribe<TowerPlacedMessage>(this);
        MessageBroadcaster.Instance.Subscribe<TowerSelectedMessage>(this);
        SetBackgroundHighlightVisibility(false);
    }
    
    private void OnDestroy()
    {
        MessageBroadcaster.Instance.Unsubscribe<TowerPlacedMessage>(this);
        MessageBroadcaster.Instance.Unsubscribe<TowerSelectedMessage>(this);
        _button.onClick.RemoveAllListeners();
    }

    void OnTowerButtonClick()
    {
        MessageBroadcaster.Instance.BroadcastMessage(new TowerSelectedMessage());
        SetBackgroundHighlightVisibility(true);
        _onClick?.Invoke();
    }

    void SetBackgroundHighlightVisibility(bool visible)
    {
        _backgroundHighlight.gameObject.SetActive(visible);
    }

    public void OnMessageReceived(TowerPlacedMessage message)
    {
        SetBackgroundHighlightVisibility(false);
    }

    public void OnMessageReceived(TowerSelectedMessage message)
    {
        SetBackgroundHighlightVisibility(false);
    }
}
