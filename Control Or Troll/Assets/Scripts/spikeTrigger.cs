using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    public GameObject failurePanel;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("공이 가시에 닿음!");
            
            if (failurePanel != null)
            {
                failurePanel.SetActive(true);
            }
            other.gameObject.SetActive(false);
        }
    }
}
