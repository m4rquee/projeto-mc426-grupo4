using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButtonPositions : ScriptableObject
{
    [SerializeField] private Transform[] _positions;

    public Transform GetPosition(int index)
    {
        return _positions[index];
    }

    public bool HasPosition(int index)
    {
        return _positions[index] != null;
    }
}
