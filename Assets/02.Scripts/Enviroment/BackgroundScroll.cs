using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("배경 스크롤 속도 설정")]
    [SerializeField] private float _scrollSpeed;

    private SpriteRenderer _spriteRenderer;
    private Material _backgroundMaterial;
    private MaterialPropertyBlock _backgroundMpb;

    //private Vector2 direction = Vector2.up;
    private Vector4 offsetVector = Vector4.zero;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _backgroundMaterial = _spriteRenderer.material;
        _backgroundMpb = new MaterialPropertyBlock();
        _spriteRenderer.GetPropertyBlock(_backgroundMpb);
        offsetVector.x = 1;
        offsetVector.y = 1;
    }

    private void Update()
    {
        offsetVector.w += _scrollSpeed * Time.deltaTime;
        _backgroundMpb.SetVector("_MainTex_ST", offsetVector);

        _spriteRenderer.SetPropertyBlock(_backgroundMpb);

        //_backgroundMaterial.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
