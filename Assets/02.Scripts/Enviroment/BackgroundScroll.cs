using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [Header("배경 스크롤 속도 설정")]
    [SerializeField] private float _scrollSpeed;

    private SpriteRenderer _spriteRenderer;
    private MaterialPropertyBlock _backgroundMpb;

    //private Vector2 direction = Vector2.up;
    private Vector4 _offsetVector = Vector4.zero;
    private int _offsetId = Shader.PropertyToID("_MainTex_ST");

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _backgroundMpb = new MaterialPropertyBlock();
        _spriteRenderer.GetPropertyBlock(_backgroundMpb);
        _offsetVector.x = 1;
        _offsetVector.y = 1;
    }

    private void Update()
    {
        _offsetVector.w += _scrollSpeed * Time.deltaTime;
        _backgroundMpb.SetVector(_offsetId, _offsetVector);

        _spriteRenderer.SetPropertyBlock(_backgroundMpb);

        //_backgroundMaterial.mainTextureOffset += direction * _scrollSpeed * Time.deltaTime;
    }
}
