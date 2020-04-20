using UnityEngine;

[CreateAssetMenu(fileName = "Stage 00", menuName = "New Stage", order = 51)]
public class StageInfo : ScriptableObject
{
    [SerializeField] private int _stageId;

    [SerializeField] private int _monsterQuantity;
    //TODO: Add wave & enemy infos here
}
