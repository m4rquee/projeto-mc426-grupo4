using UnityEngine;

[CreateAssetMenu(fileName = "TowerInfo00", menuName = "Create Tower Info", order = 52)]
public class TowerInfo : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Sprite _previewImage;
    [SerializeField] private int _price;

    public GameObject Prefab => _prefab;

    public Sprite PreviewImage => _previewImage;

    public int Price => _price;
}
