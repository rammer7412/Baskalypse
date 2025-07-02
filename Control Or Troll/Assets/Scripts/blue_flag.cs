using UnityEngine;

public class blue_flag : MonoBehaviour
{
    public Sprite flagUp;
    public Sprite flagDown;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private bool isRaised = true;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        spriteRenderer.sprite = flagUp;
        boxCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRaised = !isRaised;
            spriteRenderer.sprite = isRaised ? flagUp : flagDown;
            boxCollider.enabled = !isRaised; //When flagUp -> Off, flagDown -> On
        }
    }
}
