using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    Animator animator;
    bool isJumped = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" && !isJumped)
        {
            animator.SetTrigger("Jump");
            collision.GetComponent<Rigidbody2D>().AddForceY(jumpForce, ForceMode2D.Impulse);
            isJumped = !isJumped;
        }
    }
}
