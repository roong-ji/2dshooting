using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("사운드 목록")]
    [SerializeField] private AudioClip[] _enemyDeathSounds;
    [SerializeField] private AudioSource _enemyDeathSound;

    [SerializeField] private AudioClip[] _itemSounds;
    [SerializeField] private AudioSource _itemSound;

    [SerializeField] private AudioSource _skillSound;

    [SerializeField] private AudioSource _gameOverSound;

    private int _deathSoundIndex = 0;
    private int _itemSoundIndex = 0;

    public void PlayDeathSound()
    {
        _enemyDeathSound.PlayOneShot(_enemyDeathSounds[_deathSoundIndex]);
        _deathSoundIndex = ++_deathSoundIndex % _enemyDeathSounds.Length;
    }

    public void PlayItemSound()
    {
        _itemSound.PlayOneShot(_itemSounds[_itemSoundIndex]);
        _itemSoundIndex = ++_itemSoundIndex % _itemSounds.Length;
    }

    public void PlaySkillSound()
    {
        _skillSound.Play();
    }

    public void PlayGameOverSound()
    {
        _gameOverSound.Play();
    }

}
