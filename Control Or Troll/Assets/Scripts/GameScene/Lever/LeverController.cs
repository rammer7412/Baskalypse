using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] private GameObject leverBar;
    [SerializeField] private GameObject RedBlue;
    [SerializeField] private GameObject GreenPurple;

    [SerializeField] private Transform Left;
    [SerializeField] private Transform Right;

    private GameObject RedButton;
    private GameObject BlueButton;
    private GameObject GreenButton;
    private GameObject PurpleButton;

    bool isMoved = false;

    void Awake()
    {
        RedButton = UIManager.Instance.redButton.gameObject;
        BlueButton = UIManager.Instance.blueButton.gameObject;
        GreenButton = UIManager.Instance.greenButton.gameObject;
        PurpleButton = UIManager.Instance.purpleButton.gameObject;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isMoved)
        {
            if (other.tag == "Ball")
            {
                if (Vector2.Distance(other.transform.position, Left.position) < Vector2.Distance(other.transform.position, Right.position))
                {
                    leverBar.transform.DORotate(new Vector3(0f, 0f, -60f), 1f);
                    RedBlue.SetActive(false);
                    GreenPurple.SetActive(true);

                    RedButton.SetActive(false);
                    BlueButton.SetActive(false);
                    GreenButton.SetActive(true);
                    PurpleButton.SetActive(true);

                    isMoved = !isMoved;
                }
            }
        }
        else
        {
            if (other.tag == "Ball")
            {
                if (Vector2.Distance(other.transform.position, Left.position) > Vector2.Distance(other.transform.position, Right.position))
                {
                    leverBar.transform.DORotate(new Vector3(0f, 0f, 60f), 1f);
                    RedBlue.SetActive(true);
                    GreenPurple.SetActive(false);

                    RedButton.SetActive(true);
                    BlueButton.SetActive(true);
                    GreenButton.SetActive(false);
                    PurpleButton.SetActive(false);

                    isMoved = !isMoved;
                }
            }
        }

    }
}
