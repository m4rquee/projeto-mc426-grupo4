using Common.Broadcaster;

public class StageClickedMessage : IMessage
{
    public int SelectedStage { get; }

    //TODO: Broadcast this message when user clicks on any stage button
    public StageClickedMessage(int stageInfo)
    {
        SelectedStage = stageInfo;
    }
}
