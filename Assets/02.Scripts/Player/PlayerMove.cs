using UnityEngine;

// 플레이어 이동
public class PlayerMove : MonoBehaviour
{
    public float Speed = 3f;

    // 키보드 입력에 따라 방향을 구하고 그 방향으로 이동
    void Start()
    {
        
    }

    void Update()
    {
        // 1, 키보드 입력을 감지한다.
        float h = Input.GetAxis("Horizontal");  // 수평 입력에 대한 값을 -1 ~ 1 로 가져온다.
        float v = Input.GetAxis("Vertical");  // 수직 입력에 대한 값을 -1 ~ 1 로 가져온다.

        // 2, 입력으로부터 방향을 구한다.
        Vector2 direction = new Vector2(h, v);

        // 3. 구한 방향으로 이동한다.
        Vector2 position = transform.position;

        // 새로운 위치 = 현재 위치 + (방향 * 속력) * 시간
        // 새로운 위치 = 현재 위치 +     속도      * 시간
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
