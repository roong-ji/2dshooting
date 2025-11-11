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

        //아이템 효과 발동
        ApplyEffect(player);

        // 아이템 파티클 효과
        ItemParticleEffect(player);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    }

    protected abstract void ApplyEffect(Player player);

    private void ItemParticleEffect(Player player)
    {
        _particleComponent.PlayParticleEffect(player);
    }

}
