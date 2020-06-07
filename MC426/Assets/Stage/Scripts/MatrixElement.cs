using Common.Broadcaster;
using UnityEngine;
using UnityEngine.UI;

public class MatrixElement : MonoBehaviour
{
    [SerializeField] private GameObject _selection;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _towerAnchor;

    private MatrixElementState _currentState;
    
    public enum MatrixElementState
    {
        Default,
        Selected,
        TowerPlaced
    }
    
    void Start()
    {
        ChangeCurrentState(MatrixElementState.Default);
        _button.onClick.AddListener(OnTowerClicked);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnTowerClicked);
    }

    private void OnTowerClicked()
    {
        if (BuildMenu.CurrentTowerInfo == null || _currentState == MatrixElementState.TowerPlaced) return;
        
        Instantiate(BuildMenu.CurrentTowerInfo.Prefab, _towerAnchor.transform);
        SlimeCollector.Cash -= BuildMenu.CurrentTowerInfo.Price;
        MessageBroadcaster.Instance.BroadcastMessage(new TowerPlacedMessage());
        ChangeCurrentState(MatrixElementState.TowerPlaced);
    }

    public void ChangeCurrentState(MatrixElementState state)
    {
        _currentState = state;
        switch (state)
        {
            case MatrixElementState.Default:
            case MatrixElementState.Selected:
            {
                _selection.SetActive(true);
                _towerAnchor.SetActive(false);
                break;
            }
            case MatrixElementState.TowerPlaced:
            {
                _selection.SetActive(false);
                _towerAnchor.SetActive(true);
                break;
            }
        }
    }
}
