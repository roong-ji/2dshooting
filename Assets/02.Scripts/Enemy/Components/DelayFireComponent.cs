using UnityEngine;

public class DelayFireComponent : MonoBehaviour
{
    [SerializeField] private GameObject _fire;

    private void OnEnable()
    {
        _fire.SetActive(false);
    }

    public void StartFire()
    {
        _fire.SetActive(true);
    }
}
