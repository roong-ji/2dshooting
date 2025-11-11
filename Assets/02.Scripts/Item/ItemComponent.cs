using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{

    private ParticleComponent _particleComponent;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;
        Player player = collision.GetComponent<Player>();

        // 아이템 효과 발동
        ApplayEffect(player);

        // 아이템 획득 이펙트
        PlayItemEffect(player.transform);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    }

    private void PlayItemEffect(Transform transform)
    {
        _particleComponent.PlayParticleEffect(transform);
    }

    protected abstract void ApplayEffect(Player player);

}
