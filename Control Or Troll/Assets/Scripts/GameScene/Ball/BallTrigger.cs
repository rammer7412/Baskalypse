using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallTrigger : MonoBehaviour
{
    public GameObject failPanel;
    public GameObject buttonGroup;
    public GameObject inGameRetryBtn;
    public event Action ballDied;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes") || other.CompareTag("Arrow") || other.CompareTag("DeathZone"))
        {
            Debug.Log("사망 판정");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
            inGameRetryBtn.SetActive(false);
            ballDied?.Invoke();
        }
    }
}
