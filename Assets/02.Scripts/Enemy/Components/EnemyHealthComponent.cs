using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    [SerializeField] private ItemDropper _itemDropper;
    private ScoreManager _scoreManager;

    [Header("점수")]
    [SerializeField] private int _score;

    public override void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        MakeExplosionEffect();
        DropItem();
        AddScore();
        Destroy(gameObject);

    }
    private void DropItem()
    {

        if (_itemDropper == null) return;
        _itemDropper.DropItem(transform.position);
    }

    private void AddScore()
    {
        _scoreManager = FindAnyObjectByType<ScoreManager>();
        if (_scoreManager == null) return;
        _scoreManager.AddScore(_score);
    }

}
