using System.Collections;
using System.Collections.Generic;
using Common.Broadcaster;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectorScreenController : MonoBehaviour
{
    [SerializeField] private StageButtonPositions _positions;
    [SerializeField] private GameObject _selectorButtonPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; _positions.HasPosition(i); i++)
        {
            var goButton = Instantiate(_selectorButtonPrefab, _positions.GetPosition(i));
            var button = goButton.GetComponent<Button>();
            button.onClick.AddListener(() => OpenPlayableScene(i));
        }
    }

    void OpenPlayableScene(int sceneIndex)
    {
        // TODO: Open game scene
        MessageBroadcaster.Instance.BroadcastMessage(new StageClickedMessage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
