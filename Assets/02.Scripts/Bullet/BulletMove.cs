using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody2D;

    [SerializeField] private float _speed;
    [SerializeField] private float _flipTime;
    private float _timer = 0f;

    private Quaternion _originRotation;
    private Quaternion _flipedRotation;

    private void Start()
    {
        _originRotation = transform.rotation;
        _flipedRotation = Quaternion.Euler(0f, 0f, transform.eulerAngles.z * -1f);
    }

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;

        transform.rotation = Quaternion.Lerp(_originRotation, _flipedRotation, Mathf.PingPong(_timer / _flipTime, 1f));

        _rigidbody2D.linearVelocity = transform.up * _speed;
    }

}
