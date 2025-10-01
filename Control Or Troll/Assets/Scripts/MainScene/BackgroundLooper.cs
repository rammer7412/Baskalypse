using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float speed = 0.01f;
    private float width;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;

        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= startPos.x - width)
        {
            transform.position = new Vector3(startPos.x, transform.position.y, transform.position.z);
        }
    }
}
