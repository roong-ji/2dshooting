using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MovementComponent
{
    [SerializeField] private float _flipTime;
    private float _timer = 0f;

    private Quaternion _originRotation;
    private Quaternion _flipedRotation;

    private void Start()
    {
        _originRotation = transform.rotation;
        _flipedRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z * -1f);
    }

    protected override void Move()
    {
        _timer += Time.deltaTime;

        transform.rotation = Quaternion.Lerp(_originRotation, _flipedRotation, Mathf.PingPong(_timer / _flipTime, 1f));

        _rigidbody2D.linearVelocity = transform.up * _speed;
    }

}
