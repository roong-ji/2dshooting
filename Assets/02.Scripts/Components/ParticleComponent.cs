using UnityEngine;

public class ParticleComponent : MonoBehaviour
{
    [Header("파티클 이펙트")]
    [SerializeField] private GameObject _particlePrefab;

    public void PlayParticleEffect(Transform transform)
    {
        Instantiate(_particlePrefab, transform);
    }
}