using UnityEngine;

public class BoomComponent : MonoBehaviour
{
    [Header("스킬 지속 시간")]
    [SerializeField] private float BoomDuration;

    private ParticleComponent _particleComponent;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
        Destroy(gameObject, BoomDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return;
        Destroy(collision.gameObject);
        _particleComponent.PlayParticleEffect(collision);
    }
}
