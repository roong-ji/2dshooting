using UnityEngine;

public class HealItem : MonoBehaviour
{

    [Header("회복량")]
    [SerializeField] private float _healAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;
        // 아이템 획득 효과로 스피드업
        collision.GetComponent<HealthComponent>().Heal(_healAmount);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    }


}
