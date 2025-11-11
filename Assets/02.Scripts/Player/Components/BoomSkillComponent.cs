using UnityEngine;

public class BoomSkillComponent : MonoBehaviour
{
    [Header("스킬 프리팹")]
    [SerializeField] private GameObject _skillPrefab;

    [Header("스킬 발동 위치")]
    [SerializeField] private Vector2 _skillTransform;

    public void Boom()
    {
        Instantiate(_skillPrefab, _skillTransform, Quaternion.identity);
    }

}