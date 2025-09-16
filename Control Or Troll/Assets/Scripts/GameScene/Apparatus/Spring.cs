using Unity.VisualScripting;
using UnityEngine;

public class Spring : MonoBehaviour
{
    [SerializeField] private float springForce = 2f;
    [SerializeField] private float maxHeight = 100f;
    [SerializeField] private bool isHorizontal = false;
    private int index;

    void Update()
    {
        index = Ball.Instance.gameObject.GetComponent<Rigidbody2D>().linearVelocityX < 0 ? 1 : -1;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!isHorizontal)
        {
            if (other.transform.CompareTag("Ball"))
            {
                float force = -1 * (other.gameObject.GetComponent<Rigidbody2D>().linearVelocity.y + springForce);

                Ball.Instance.transform.GetComponent<Rigidbody2D>()
                .AddForceY(maxHeight < force
                            ? -1 * other.gameObject.GetComponent<Rigidbody2D>().linearVelocity.y + maxHeight
                            : -1 * other.gameObject.GetComponent<Rigidbody2D>().linearVelocity.y + force, ForceMode2D.Impulse);
            }
        }
        else
        {
            if (other.transform.CompareTag("Ball"))
            {
                float force = other.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x + springForce;

                Ball.Instance.transform.GetComponent<Rigidbody2D>().AddForceX(index * (other.gameObject.GetComponent<Rigidbody2D>().linearVelocity.x + force), ForceMode2D.Impulse);
            }
        }
    }
}
