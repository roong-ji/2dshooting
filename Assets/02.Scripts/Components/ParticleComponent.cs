using UnityEngine;

public class ParticleComponent : MonoBehaviour
{
    [Header("파티클 이펙트")]
    [SerializeField] private GameObject _particlePrefab;

    public void PlayParticleEffect(Transform transform)
    {
        Instantiate(_particlePrefab, transform);
    }

    public void PlayParticleEffect(Vector2 position)
    {
        Instantiate(_particlePrefab, position, Quaternion.identity);
    }


    public void PlayParticleEffect()
    {
        Instantiate(_particlePrefab, transform.position, Quaternion.identity);
    }

}