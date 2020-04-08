using Common.Broadcaster;

public class StageClickedMessage : IMessage
{
    public StageInfo StageInfo { get; }

    //TODO: Broadcast this message when user clicks on any stage button
    public StageClickedMessage(StageInfo stageInfo)
    {
        StageInfo = stageInfo;
    }
}
