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
        // 가중치 총합 계산
        _totalWeight = 0;
        foreach(var weight in _weights)
        {
            _totalWeight += weight;
        }
    }

    public void DropItem()
    {
        // 아이템을 드랍할 것인지 확인
        if (Random.value > _dropRate) return;

        int itemIndex = 0;
        int randomWeight = Random.Range(0, _totalWeight);
        foreach (var weight in _weights)
        {
            // 난수가 현재 아이템 가중치 범위 내인지 체크
            if (randomWeight < weight) break;

            // 다음 아이템 가중치 범위 확인
            ++itemIndex;
            randomWeight -= weight;
        }
        // 아이템 드랍
        Instantiate(_items[itemIndex], transform.position, Quaternion.identity);
    }

}
