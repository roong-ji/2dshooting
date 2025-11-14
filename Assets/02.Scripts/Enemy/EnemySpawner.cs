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

    [Header("보스 스폰 점수")]
    [SerializeField] private int _bossScore;
    private int _nextBossScore;

    Vector2 spawnPosition;
    private float _timer = 0f;

    private void Awake()
    {
        spawnPosition = transform.position;
        _nextBossScore = _bossScore;
    }

    private void Update()
    {
        if (EnemyFactory.Instance.BossSpawned == true) return;

        _timer+= Time.deltaTime;
        if(_timer >= _spawnInterval)
        {
            SpawnEnemy();
            _timer = 0f;
        }

        if (ScoreManager.Instance.TotalScore < _nextBossScore) return;
        SpawnBoss();
    }

    private void SpawnEnemy()
    {
        EEnemyType enemyType = Random.value < _spawnChance[0] ? EEnemyType.Charge : EEnemyType.Chase;
        enemyType = Random.value < _spawnChance[1] ? enemyType : EEnemyType.Evade;

        spawnPosition.x = Random.Range(_minSpawnX, _maxSpawnX);

        EnemyFactory.Instance.MakeEnemy(enemyType, spawnPosition);

        _spawnInterval = Random.Range(_minSpawnInterval, _maxSpawnInterval);
    }

    private void SpawnBoss()
    {
        spawnPosition.x = 0f;
        EnemyFactory.Instance.ReturnAllEnemy();
        EnemyFactory.Instance.MakeBossEnemy(spawnPosition);

        _nextBossScore += _bossScore;
    }
}
