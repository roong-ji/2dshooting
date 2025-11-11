using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("배경 스크롤 속도 설정")]
    [SerializeField] private float _scrollSpeed;
    private Material _backgroundMaterial;
    private Vector2 direction = Vector2.up;

    private void Awake()
    {
        _backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        _backgroundMaterial.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
