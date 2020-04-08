using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.Scripts
{
    public class MenuButtonsController : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _quitButton;

        private const string StageSelectorSceneName = "StageSelector";

        private void Start()
        {
            _playButton.onClick.AddListener(OnPlayButtonClick);
            _quitButton.onClick.AddListener(OnQuitButtonClick);
        }

        private void OnDestroy()
        {
            _playButton.onClick.RemoveAllListeners();
        }

        private void OnPlayButtonClick()
        {
            // Loading a second scene which should be the stage selector
            SceneManager.LoadScene(StageSelectorSceneName);
        }

        private void OnQuitButtonClick()
        {
            // Exiting the application
            Application.Quit(0);
        }
    }
}
