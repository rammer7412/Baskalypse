using UnityEngine;

public class portalTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject successPanel;
    void OnTriggerEnt2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("도착!");
            if (successPanel != null)
            {
                successPanel.SetActive(true);
            }
        }
    }
}
