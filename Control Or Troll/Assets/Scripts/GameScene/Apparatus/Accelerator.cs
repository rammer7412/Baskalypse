using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField] private float Force = 5f;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            collision.GetComponent<Rigidbody2D>().AddForceX(Force, ForceMode2D.Force);
        }
    }
}
