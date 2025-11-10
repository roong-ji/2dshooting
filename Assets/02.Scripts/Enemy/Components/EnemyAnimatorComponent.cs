using UnityEngine;

public class EnemyAnimatorComponent : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayHitAnimation()
    {
        _animator.SetTrigger("hit");
    }

}
