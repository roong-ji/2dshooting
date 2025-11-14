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
    [SerializeField] private EnemyData[] _enemies;
    [SerializeField] private GameObject _bossPrefab;
    private GameObject _bossInstance;

    public bool BossSpawned => _bossInstance !=null && _bossInstance.activeSelf;

    private Dictionary<EEnemyType, List<GameObject>> _enemyPools;

    private void Start()
    {
        InitPool();
    }

    private void InitPool()
    {
        _enemyPools = new Dictionary<EEnemyType, List<GameObject>>();

        foreach (var enemy in _enemies)
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

    public GameObject MakeBossEnemy(Vector3 position)
    {
        if(_bossInstance == null)
        {
            _bossInstance = Instantiate(_bossPrefab, transform);
        }

        _bossInstance.transform.position = position;
        _bossInstance.SetActive(true);

        return _bossInstance;
    }

    public GameObject MakeEnemy(EEnemyType enemyType, Vector3 position)
    {
        ref int index = ref _enemies[(int)enemyType].Index;
        int size = _enemies[(int)enemyType].PoolSize;

        GameObject enemy = _enemyPools[enemyType][index];

        if (enemy.activeSelf == true)
        {
            index = size;
            ExpandPool(enemyType);
            size *= 2;
        }

        enemy.transform.position = position;
        enemy.SetActive(true);

        index = ++index % size;

        return enemy;
    }

    private void ExpandPool(EEnemyType enemyType)
    {
        ref EnemyData enemy = ref _enemies[(int)enemyType];

        for (int i = 0; i < enemy.PoolSize; ++i)
        {
            GameObject newBullet = Instantiate(enemy.Prefab, transform);
            _enemyPools[enemyType].Add(newBullet);
            newBullet.SetActive(false);
        }
        enemy.PoolSize *= 2;
    }

    public void ReturnAllEnemy()
    {
        foreach (var enemyPool in _enemyPools)
        {
            foreach (var enemy in enemyPool.Value)
            {
                enemy.SetActive(false);
            }
        }
    }
}
