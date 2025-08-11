using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class WindMaker : MonoBehaviour
{
    [SerializeField] float windForce = 8f;
    [SerializeField] private float maxDistance = 8f;
    private float distance;
    private Vector2 direction;
    private float windOffset;
    

    void FixedUpdate()
    {
        windOffset = Random.Range(4f, 5f);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            distance = Vector2.Distance(Ball.Instance.transform.position, transform.position); 

            direction = (Ball.Instance.transform.position - transform.position) * windOffset; // 힘을 줄 방향 계산
            float normalized = Mathf.Clamp01((maxDistance - distance) / maxDistance); // 거리에 따른 바람 세기 감소 구현 
            Ball.Instance.transform.GetComponent<Rigidbody2D>().AddForce(direction * normalized * windOffset, ForceMode2D.Force);
        }
    }
}
