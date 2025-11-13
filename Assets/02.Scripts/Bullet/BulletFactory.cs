using System;
using System.Collections.Generic;
using UnityEngine;

public enum EBulletType
{
    PlayerBullet = 0,
    PlayerSmallBullet = 1,
    EnemyBullet = 2,
    PetBullet = 3,
}

[Serializable]
public struct BulletData
{
    public EBulletType Type;
    public GameObject Prefab;
    public int PoolSize;
    public int Index;
}

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
    [SerializeField] private BulletData[] _bullets;

    private Dictionary<EBulletType, List<GameObject>> _bulletPools;

    private void Start()
    {
        InitPool();
    }

    private void InitPool()
    {
        _bulletPools = new Dictionary<EBulletType, List<GameObject>>();

        foreach (var bullet in _bullets)
        {
            List<GameObject> pool = new List<GameObject>(bullet.PoolSize);

            for (int i = 0; i< bullet.PoolSize; ++i)
            {
                GameObject newBullet = Instantiate(bullet.Prefab, transform);
                pool.Add(newBullet);
                newBullet.SetActive(false);
            }

            _bulletPools.Add(bullet.Type, pool);
        }
    }

    public GameObject MakeBullet(EBulletType bulletType, Vector3 position, Quaternion quaternion)
    {
        ref int index = ref _bullets[(int)bulletType].Index;
        int size = _bullets[(int)bulletType].PoolSize;
        index = index++ % size;

        GameObject bullet = _bulletPools[bulletType][index];
        bullet.transform.position = position;
        bullet.transform.rotation = quaternion;
        bullet.SetActive(true);

        return bullet;
    }

}
