using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    [Header("스탯")]
    private float _health = 100f;

    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private float _knockBackSpeed;
    [SerializeField] private bool _isKnockBack;
    private float _timer = 0f;
    private float _knockBackDuration = 0.5f;


    private void FixedUpdate()
    {
        if(!_isKnockBack)
        {
            _rigidbody2D.linearVelocity = Vector2.down * _speed;
            return;
        }

        if(_timer >= _knockBackDuration)
        {
            _timer = 0f;
            _isKnockBack = false;
            return;
        }

        _timer += Time.fixedDeltaTime;
        _rigidbody2D.linearVelocityY = Mathf.Lerp(_rigidbody2D.linearVelocityY, 0, _timer / _knockBackDuration) ;

    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void KnockBack()
    {
        _isKnockBack = true;
        _rigidbody2D.linearVelocityY = _knockBackSpeed;
    }


}
