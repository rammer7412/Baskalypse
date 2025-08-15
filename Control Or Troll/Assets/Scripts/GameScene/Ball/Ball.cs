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
    [SerializeField] private GameObject ballParticle;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D ballRb;
    private BallType ballType;
    
    private bool isNowGravityEffect = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ballRb = GetComponent<Rigidbody2D>();
        ballType = BallType.Normal;
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
            if (isNowGravityEffect) ballParticle.SetActive(false); 
            else ballParticle.SetActive(true);

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



}
