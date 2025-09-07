using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasketGoal : MonoBehaviour
{
    [Header("직접 입력한 총 공 개수")]
    public int totalBallCount = 3;

    private HashSet<Collider2D> ballsInside = new HashSet<Collider2D>();
    private GameObject successPanel;

    void Awake()
    {
        successPanel = UIManager.Instance.successPanel;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball") && !ballsInside.Contains(other))
        {
            StartCoroutine(CheckBallStay(other));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            ballsInside.Remove(other);
        }
    }

    IEnumerator CheckBallStay(Collider2D ball)
    {
        yield return new WaitForSeconds(2f);

        if (IsBallStillInside(ball))
        {
            ballsInside.Add(ball);
            Debug.Log($"공 {ballsInside.Count}/{totalBallCount} 바구니에 들어옴");

            if (ballsInside.Count >= totalBallCount)
            {
                Debug.Log("모든 공이 바구니 안에 2초간 머무름 → 성공!");
                successPanel.SetActive(true);
            }
        }
    }

    bool IsBallStillInside(Collider2D ball)
    {
        return GetComponent<Collider2D>().bounds.Contains(ball.transform.position);
    }
}
