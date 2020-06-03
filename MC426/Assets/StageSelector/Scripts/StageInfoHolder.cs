using System.Collections.Generic;
using Common.Broadcaster;
using UnityEngine;

namespace StageSelector.Scripts
{
    // This class exists because we need a class to 'survive' a scene unload, which
    // is what MonoSingletons do.
    // We need this class to 'survive' it because we need to know which stage was the one that the user selected
    // in another scene which is not opened yet.
    public class StageInfoHolder : MonoSingleton<StageInfoHolder>, IMessageSubscriber<StageClickedMessage>
    {
        private StageInfo _stageInfo;
        private bool _isLocked;

        [SerializeField] private List<StageInfo> _stagesInOrder;

        private void Start()
        {
            MessageBroadcaster.Instance.Subscribe(this);
        }

        private void OnDestroy()
        {
            MessageBroadcaster.Instance.Unsubscribe(this);
        }

        public void LockStageInfo()
        {
            _isLocked = true;
        }

        public void UnlockStageInfo()
        {
            _isLocked = false;
        }

        public void SetLastClickedStage(StageInfo stageInfo)
        {
            if (_isLocked) return;

            _stageInfo = stageInfo;
        }

        public StageInfo GetInfoFromLastClickedStage()
        {
            return _stageInfo;
        }

        bool HasStageIndex(int index)
        {
            return _stagesInOrder.Count > index && index >= 0 && _stagesInOrder[index] != null;
        }

        public void OnMessageReceived(StageClickedMessage message)
        {
            if (HasStageIndex(message.SelectedStage))
            {
                SetLastClickedStage(_stagesInOrder[message.SelectedStage]);
            }
        }
    }
}
