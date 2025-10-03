using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallTrigger : MonoBehaviour
{
    public GameObject failPanel;
    public GameObject buttonGroup;
    public GameObject inGameRetryBtn;
    public GameObject inGameMenuBtn;
    public event Action ballDied;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            Debug.Log("사망 판정");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
            inGameRetryBtn.SetActive(false);
            inGameMenuBtn.SetActive(false);
            ballDied?.Invoke();
        }
        else if (other.CompareTag("Arrow")) {
            Debug.Log("사망 판정");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
            inGameRetryBtn.SetActive(false);
            inGameMenuBtn.SetActive(false);
            ballDied?.Invoke();
        }
        else if (other.CompareTag("DeathZone")) {
            Debug.Log("사망 판정");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
            inGameRetryBtn.SetActive(false);
            inGameMenuBtn.SetActive(false);
            ballDied?.Invoke();
        }
    }
}
