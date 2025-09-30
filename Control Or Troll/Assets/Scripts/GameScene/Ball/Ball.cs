using System;
using Unity.VisualScripting;
using UnityEngine;

public enum BallType
{
    Normal, Iron
};

public class Ball : Singleton<Ball>
{

    protected Ball() { }

    [SerializeField] private Sprite NormalBall;
    [SerializeField] private Sprite IronBall;
    [SerializeField] private Sprite GravityBall;
    [SerializeField] public GameObject explosionParticle;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D ballRb;
    private BallType ballType;
    private BallTrigger ballTrigger;

    private bool isNowGravityEffect = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballRb = GetComponent<Rigidbody2D>();
        ballType = BallType.Normal;
        ballTrigger = GetComponent<BallTrigger>();
        ballTrigger.ballDied += Explosion;
    }


    public void ChangeBall(string type)
    {
        if (type == "Normal")
        {
            spriteRenderer.sprite = NormalBall;
            ballRb.gravityScale = 1;
            ballType = BallType.Normal;
        }
        else if (type == "Iron")
        {
            spriteRenderer.sprite = IronBall;
            ballRb.gravityScale = 3;
            ballType = BallType.Iron;
        }
        else if (type == "Gravity")
        {
            spriteRenderer.sprite = GravityBall;

            ballRb.gravityScale = -1 * ballRb.gravityScale;
            isNowGravityEffect = !isNowGravityEffect;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block" && ballType == BallType.Iron)
        {
            collision.gameObject.GetComponent<Block>().BlockBreak();
        }
    }

    private void Explosion()
    {
        explosionParticle.SetActive(true);
        GetComponent<Rigidbody2D>().freezeRotation = true;
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
    }

}
