using UnityEngine;

public abstract class Bullet : MonoBehaviour
{

    [Header("공격력")]
    [SerializeField] protected float _damage;

    protected abstract bool ShouldHit(GameObject target);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ShouldHit(collision.gameObject) == false) return;
        gameObject.SetActive(false);
    }
}
