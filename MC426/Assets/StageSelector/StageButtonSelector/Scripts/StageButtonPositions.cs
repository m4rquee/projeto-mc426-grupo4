using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonPositions : MonoBehaviour
{
    [SerializeField] private List<GameObject> _positions;

    public Transform GetPosition(int index)
    {
        return _positions[index].transform;
    }

    public bool HasPosition(int index)
    {
        return index < _positions.Count && index >= 0 && _positions[index] != null;
    }

    void ChangePlaceholderVisibility(bool visibility)
    {
        foreach (var position in _positions)
        {
            position.GetComponent<Image>().enabled = visibility;
        }
    }

    void Start()
    {
        ChangePlaceholderVisibility(false);
    }

    void OnDestroy()
    {
        ChangePlaceholderVisibility(true);
    }
}
