using UnityEngine;

public class SpeedupItem : MonoBehaviour
{

    [Header("이동 속도 상승치")]
    [SerializeField] private float _speedupAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == false) return;
        // 스피드업
        collision.GetComponent<PlayerMove>().Speedup(_speedupAmount);

        // 아이템 오브젝트 제거
        Destroy(gameObject);
    
    }

}
