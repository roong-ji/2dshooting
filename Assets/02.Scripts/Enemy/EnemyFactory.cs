using System;
using System.Collections.Generic;
using UnityEngine;

public enum EEnemyType
{
    Charge = 0,
    Chase = 1,
    Evade = 2,
}

[Serializable]
public struct EnemyData
{
    public EEnemyType Type;
    public GameObject Prefab;
    public int PoolSize;
    public int Index;
}

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory _instance;
    public static EnemyFactory Instance
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

    [Header("몬스터 프리팹")]
    [SerializeField] private EnemyData[] _enemyes;

    private Dictionary<EEnemyType, List<GameObject>> _enemyPools;

    private void Start()
    {
        InitPool();
    }

    private void InitPool()
    {
        _enemyPools = new Dictionary<EEnemyType, List<GameObject>>();

        foreach (var enemy in _enemyes)
        {
            List<GameObject> pool = new List<GameObject>(enemy.PoolSize);

            for (int i = 0; i < enemy.PoolSize; ++i)
            {
                GameObject newEnemy = Instantiate(enemy.Prefab, transform);
                pool.Add(newEnemy);
                newEnemy.SetActive(false);
            }

            _enemyPools.Add(enemy.Type, pool);
        }
    }

    public GameObject MakeEnemy(EEnemyType enemyType, Vector3 position, Quaternion quaternion)
    {
        ref int index = ref _enemyes[(int)enemyType].Index;
        int size = _enemyes[(int)enemyType].PoolSize;
        index = index++ % size;

        GameObject enemy = _enemyPools[enemyType][index];
        enemy.transform.position = position;
        enemy.transform.rotation = quaternion;
        enemy.SetActive(true);

        return enemy;
    }
}
