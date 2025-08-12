using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float aliveTime = 3f;
    private float nowTime = 0f;


    void Update()
    {
        nowTime += Time.deltaTime;

        if (nowTime > aliveTime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }

}
