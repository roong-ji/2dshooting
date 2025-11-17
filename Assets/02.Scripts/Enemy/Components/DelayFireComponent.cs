using UnityEngine;

public class DelayFireComponent : MonoBehaviour
{
    [SerializeField] private GameObject _fire;
    [SerializeField] private float _delayTime;

    private void OnEnable()
    {
        Invoke(nameof(StartFire), _delayTime);
    }

    public void StartFire()
    {
        _fire.SetActive(true);
    }
}
