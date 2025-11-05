using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("몬스터 프리팹")]
    [SerializeField] private GameObject _enemyPrefab;

    [Header("스폰 범위")]
    [SerializeField] private float _minSpawnX;
    [SerializeField] private float _maxSpawnX;

    [Header("스폰 간격")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _maxSpawnInterval;
    private float _timer = 0f;

    private void Update()
    {
        _timer+= Time.deltaTime;
        if(_timer >= _spawnInterval)
        {
            SpawnEnemy();
            _timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab);
        Vector3 pos = enemy.transform.position;
        pos.x = Random.Range(_minSpawnX, _maxSpawnX);
        enemy.transform.position = pos;

        _spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }
}
