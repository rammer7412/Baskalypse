using UnityEngine;
using System.Collections;

public class GoalDetector : MonoBehaviour
{
    private Coroutine successCoroutine;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            successCoroutine = StartCoroutine(WaitForBallStay(other));

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ball") && successCoroutine != null)
        {
            StopCoroutine(successCoroutine);
            successCoroutine = null;
        }
    }

    IEnumerator WaitForBallStay(Collider2D ball)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("공이 2초 동안 바구니 안에 있었음 → 성공!");
    }
}
