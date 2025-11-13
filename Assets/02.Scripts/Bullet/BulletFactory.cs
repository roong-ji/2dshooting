using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory _instance;
    public static BulletFactory Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }

    [Header("총알 프리팹")]
    [SerializeField] protected GameObject[] _bulletPrefab;

    public GameObject MakeBullet(EBulletType bulletType, Vector3 position, Quaternion quaternion)
    {
        return Instantiate(_bulletPrefab[(int)bulletType], position, quaternion, transform);
    }
}
