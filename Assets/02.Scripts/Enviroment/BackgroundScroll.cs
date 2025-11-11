using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("배경 스크롤 속도 설정")]
    [SerializeField] private float _scrollSpeed;
    private Material _backgroundMaterial;

    private void Awake()
    {
        _backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        // 방향을 구한다.
        Vector2 direction = Vector2.up;
        // 움직인다.
        _backgroundMaterial.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
