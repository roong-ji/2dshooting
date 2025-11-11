using UnityEngine;

public class ParticleComponent : MonoBehaviour
{
    [Header("파티클 이펙트")]
    [SerializeField] private GameObject _particlePrefab;

    public void PlayParticleEffect(Player player)
    {
        Instantiate(_particlePrefab, player.transform.position, Quaternion.identity, player.transform);
    }
    public void PlayParticleEffect(Collider2D collision)
    {
        Instantiate(_particlePrefab, collision.transform.position, Quaternion.identity);
    }

    public void PlayParticleEffect()
    {
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }
}
