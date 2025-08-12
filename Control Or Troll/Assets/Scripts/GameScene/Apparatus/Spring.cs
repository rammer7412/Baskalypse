using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float springForce = 2f;
    [SerializeField] private float maxHeight = 100f;
    

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            float force = -1 * other.GetComponent<Rigidbody2D>().linearVelocity.y + springForce;

            Ball.Instance.transform.GetComponent<Rigidbody2D>()
            .AddForceY(maxHeight < force
                        ? -1 * other.GetComponent<Rigidbody2D>().linearVelocity.y + maxHeight 
                        : -1 * other.GetComponent<Rigidbody2D>().linearVelocity.y + force, ForceMode2D.Impulse);
        }
    }
}
