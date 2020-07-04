using System;
using System.Collections;
using System.Collections.Generic;
using Common.Broadcaster;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectorScreenController : MonoBehaviour
{
    [SerializeField] private StageButtonPositions _positions;
    [SerializeField] private GameObject _selectorButtonPrefab;
    [SerializeField] private Animator _blockedStageWarningAnimator;
    private GameObject[] buttons = new GameObject[10];

    private int previousUnlockedStages = StageSelectorStagesLoader.getUnlockedStages();
    private static readonly int Appear = Animator.StringToHash("Appear");

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; _positions.HasPosition(i); i++)
        {
            var currentPosition = _positions.GetPosition(i);
            var goButton = Instantiate(_selectorButtonPrefab, currentPosition);
            var buttonController = goButton.GetComponent<StageButtonController>();
            var localIndex = i;
            buttonController.Init(i, IsStageBlocked(i), () => OpenPlayableScene(localIndex));
            buttons[i] = goButton;
        }
    }

    void Update()
    {
        if (previousUnlockedStages == StageSelectorStagesLoader.getUnlockedStages()) return;
        for (var i = 0; i < buttons.Length; i++)
        {
            var buttonController = buttons[i].GetComponent<StageButtonController>();
            buttonController.UpdateSprite(IsStageBlocked(i));
        }
        previousUnlockedStages = StageSelectorStagesLoader.getUnlockedStages();
    }

    public void OpenPlayableScene(int sceneIndex)
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

    public GameObject getButton(int index)
    {
        if (index >= buttons.Length || index < 0) return null;
        return buttons[index];
    }

    public bool IsStageBlocked(int index)
    {
        // O index sempre é pos-1
        return (StageSelectorStagesLoader.getUnlockedStages() <= index);
    }
}
