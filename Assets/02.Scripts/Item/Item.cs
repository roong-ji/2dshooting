using UnityEngine;

public class Item : MonoBehaviour
{

    [Header("이동 속도 상승치")]
    [SerializeField] private float _speedUpAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;
        // 아이템 획득 효과로 스피드업
        collision.GetComponent<PlayerMove>().SpeedIncrease(_speedUpAmount);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    
    }

}
