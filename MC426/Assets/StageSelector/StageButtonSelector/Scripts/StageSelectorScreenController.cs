using System.Collections;
using System.Collections.Generic;
using Common.Broadcaster;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            var buttonText = goButton.GetComponentInChildren<Text>();
            buttonText.text = "Fase " + (i + 1).ToString("00");
            var localIndex = i;
            button.onClick.AddListener(() => OpenPlayableScene(localIndex));
        }
    }

    void OpenPlayableScene(int sceneIndex)
    {
        // TODO: Open game scene
        Debug.Log("Clicou no botão de entrar na fase número: " + (sceneIndex+1).ToString("00"));
        MessageBroadcaster.Instance.BroadcastMessage(new StageClickedMessage(sceneIndex));
        SceneManager.LoadScene("Stage");
    }
}
