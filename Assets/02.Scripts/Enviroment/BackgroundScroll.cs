using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("배경 스크롤 설정")]
    [SerializeField] private Material _backgroundMaterial;
    [SerializeField] private float _scrollSpeed;

    private void Awake()
    {
        _backgroundMaterial.mainTextureOffset = Vector2.zero;
    }

    private void Update()
    {
        // 방향을 구한다.
        Vector2 direction = Vector2.up;
        // 움직인다.
        _backgroundMaterial.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
