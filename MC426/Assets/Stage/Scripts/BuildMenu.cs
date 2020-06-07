using System;
using Common.Broadcaster;
using UnityEngine;

public class BuildMenu : MonoBehaviour, IMessageSubscriber<TowerPlacedMessage>
{
    public static TowerInfo CurrentTowerInfo { get; private set; }
    [SerializeField] private TowerInfo[] towers;
    [SerializeField] private GameObject _buttonPrefab;

    private void Start()
    {
        MessageBroadcaster.Instance.Subscribe<TowerPlacedMessage>(this);
        for (var i = 0; i < towers.Length; i++)
        {
            var tower = towers[i];
            var newButton = Instantiate(_buttonPrefab, transform);
            var buttonController = newButton.GetComponent<TowerButtonController>();
            var localIndex = i;
            buttonController.Setup(tower, () => OnButtonClick(localIndex));
        }
    }

    private void OnDestroy()
    {
        MessageBroadcaster.Instance.Unsubscribe<TowerPlacedMessage>(this);
    }

    void OnButtonClick(int buttonIndex)
    {
        CurrentTowerInfo = towers[buttonIndex];
    }

    public void OnMessageReceived(TowerPlacedMessage message)
    {
        CurrentTowerInfo = null;
    }
}
