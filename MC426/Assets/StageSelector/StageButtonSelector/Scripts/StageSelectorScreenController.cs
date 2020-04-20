using System;
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
    [SerializeField] private GameObject _blockedStageWarning;

    private Coroutine _blockedStageCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        _blockedStageWarning.SetActive(false);
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
        //TODO: Verificar quando uma fase está bloqueada ou não para abrí-la
        //por enquanto temos apenas a fase teste, então apenas verificamos a primeira
        if (sceneIndex == 0)
        {
            _blockedStageWarning.SetActive(false);
            Debug.Log("Clicou no botão de entrar na fase número: " + (sceneIndex + 1).ToString("00"));
            MessageBroadcaster.Instance.BroadcastMessage(new StageClickedMessage(sceneIndex));
            SceneManager.LoadScene("Stage");
        }
        else
        {
            _blockedStageWarning.SetActive(true);
            _blockedStageCoroutine = StartCoroutine(CloseWarningAfterTime(5));
        }
    }

    IEnumerator CloseWarningAfterTime(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        _blockedStageWarning.SetActive(false);
    }

    private void OnDestroy()
    {
        StopCoroutine(_blockedStageCoroutine);
    }
}
