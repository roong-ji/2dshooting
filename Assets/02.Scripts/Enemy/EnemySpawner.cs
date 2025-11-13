using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("스폰 확률")]
    [SerializeField] private float[] _spawnChance;

    [Header("스폰 범위")]
    [SerializeField] private float _minSpawnX;
    [SerializeField] private float _maxSpawnX;

    [Header("스폰 간격")]
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _minSpawnInterval;
    [SerializeField] private float _maxSpawnInterval;

    Vector2 spawnPosition;
    private float _timer = 0f;

    private void Awake()
    {
        spawnPosition = transform.position;
    }

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
        EEnemyType enemyType = Random.value < _spawnChance[0] ? EEnemyType.Charge : EEnemyType.Chase;
        enemyType = Random.value < _spawnChance[1] ? enemyType : EEnemyType.Evade;

        spawnPosition.x = Random.Range(_minSpawnX, _maxSpawnX);

        EnemyFactory.Instance.MakeEnemy(enemyType, spawnPosition, Quaternion.identity);

        _spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }
}
