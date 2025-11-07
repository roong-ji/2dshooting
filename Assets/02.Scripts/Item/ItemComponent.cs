using UnityEngine;

public abstract class ItemComponent : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;
        Player player = collision.GetComponent<Player>();

        //아이템 효과 발동
        ApplayEffect(player);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    }

    protected abstract void ApplayEffect(Player player);

}
