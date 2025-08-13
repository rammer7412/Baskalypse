using UnityEngine;
using UnityEngine.SceneManagement;

public class BallTrigger : MonoBehaviour
{
    public GameObject failPanel;
    public GameObject buttonGroup;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spikes"))
        {
            Debug.Log("공이 가시에 닿음!");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
        }
        else if (other.CompareTag("Arrow"))
        {
            Debug.Log("화살에 닿음~");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
        }
        else if (other.CompareTag("DeathZone"))
        {
            Debug.Log("데스존에 닿음!");
            failPanel.SetActive(true);
            buttonGroup.SetActive(false);
        }
    }
}
