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
    [SerializeField] private Animator _blockedStageWarningAnimator;

    private static readonly int Appear = Animator.StringToHash("Appear");

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; _positions.HasPosition(i); i++)
        {
            var goButton = Instantiate(_selectorButtonPrefab, _positions.GetPosition(i));
            var buttonController = goButton.GetComponent<StageButtonController>();
            var localIndex = i;
            buttonController.Init(i, IsStageBlocked(i), () => OpenPlayableScene(localIndex));
        }
    }

    void OpenPlayableScene(int sceneIndex)
    {
        if (!IsStageBlocked(sceneIndex))
        {
            Debug.Log("Clicou no botão de entrar na fase número: " + (sceneIndex + 1).ToString("00"));
            MessageBroadcaster.Instance.BroadcastMessage(new StageClickedMessage(sceneIndex));
            SceneManager.LoadScene("Stage");
        }
        else
        {
            _blockedStageWarningAnimator.SetTrigger(Appear);
        }
    }
    
    bool IsStageBlocked(int index)
    {
        //TODO: Verificar quando uma fase está bloqueada ou não para abrí-la
        //por enquanto temos apenas a fase teste, então apenas verificamos a primeira
        return index != 0;
    }
}
