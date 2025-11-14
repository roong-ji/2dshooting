using UnityEngine;

public class EnemyHealthComponent : HealthComponent
{
    [SerializeField] private ItemDropper _itemDropper;

    [Header("점수")]
    [SerializeField] private int _score;
    [SerializeField] private float _roundScore;

    protected override void InitHealth()
    {
        // 누적 점수에 따라 몬스터의 체력이 높아진다.
        float round = 1;
        round += ScoreManager.Instance.Score / _roundScore;
        _health = _maxHealth * round;
    }

    public override void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health > 0f) return;
        MakeExplosionEffect();
        Death();
    }
    private void DropItem()
    {
        if (_itemDropper == null) return;
        _itemDropper.DropItem(transform.position);
    }

    private void AddScore()
    {
        ScoreManager.Instance.AddScore(_score);
    }
    protected override void PlayDeathSound()
    {
        SoundManager.Instance.PlayDeathSound();
    }

    public void Death()
    {
        DropItem();
        AddScore();
        PlayDeathSound();
        gameObject.SetActive(false);
    }

}
