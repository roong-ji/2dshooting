using UnityEngine;

public class ItemDropComponent : MonoBehaviour
{
    [Header("아이템 목록")]
    [SerializeField] private GameObject[] _items;
    [SerializeField] private int[] _weights;

    [Header("아이템 드랍 확률")]
    [SerializeField] private float _dropRate;

    private int _totalWeight;

    private void Start()
    {
        _totalWeight = 0;
        foreach(var weight in _weights)
        {
            _totalWeight += weight;
        }
    }

    public void DropItem()
    {
        if (Random.value > _dropRate) return;

        int itemIndex = 0;
        int randomWeight = Random.Range(0, _totalWeight);
        foreach (var weight in _weights)
        {
            if (randomWeight < weight) break;
            ++itemIndex;
            randomWeight -= weight;
        }
        Instantiate(_items[itemIndex], transform.position, Quaternion.identity);
    }

}
