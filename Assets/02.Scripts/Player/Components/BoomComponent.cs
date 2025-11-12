using UnityEngine;

public class BoomComponent : MonoBehaviour
{
    [Header("스킬 지속 시간")]
    [SerializeField] private float _boomDuration;

    private ParticleComponent _particleComponent;

    private void Awake()
    {
        _particleComponent = GetComponent<ParticleComponent>();
        Destroy(gameObject, _boomDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") == false) return;
        _particleComponent.PlayParticleEffect(collision.transform.position);

        EnemyHealthComponent enemy = collision.GetComponent<EnemyHealthComponent>();

        if (enemy == null) Destroy(collision.gameObject);
        else enemy.Death();
    }
}
