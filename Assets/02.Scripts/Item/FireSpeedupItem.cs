using UnityEngine;

public class FireSpeedupItem : MonoBehaviour
{
    [Header("발사 속도 증가량")]
    [SerializeField] private float _fireSpeedupAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;
        // 아이템 획득 효과로 스피드업
        collision.GetComponent<PlayerFireComponent>().FireSpeedup(_fireSpeedupAmount);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    }

}
