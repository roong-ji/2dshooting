using UnityEngine;

public class DelayParticleComponent : ParticleComponent
{
    [Header("연출 지연 시간")]
    [SerializeField] private float _delayTime;

    private void OnDisable()
    {
        Invoke(nameof(PlayParticleEffect), _delayTime);
    }
}
