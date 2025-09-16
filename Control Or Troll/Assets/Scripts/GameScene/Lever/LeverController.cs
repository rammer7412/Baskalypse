using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] private GameObject leverBar;
    [SerializeField] private GameObject RedBlue;
    [SerializeField] private GameObject GreenPurple;
    [SerializeField] private GameObject handle;

    [SerializeField] private Transform Left;
    [SerializeField] private Transform Right;

    private GameObject RedButton;
    private GameObject BlueButton;
    private GameObject GreenButton;
    private GameObject PurpleButton;

    public bool isGP = false;

    void Awake()
    {
        RedButton = UIManager.Instance.redButton.gameObject;
        BlueButton = UIManager.Instance.blueButton.gameObject;
        GreenButton = UIManager.Instance.greenButton.gameObject;
        PurpleButton = UIManager.Instance.purpleButton.gameObject;
    }

    void Start()
    {
        handle.gameObject.SetActive(true);
        if (isGP)
        {
            handle.transform.rotation = Quaternion.Euler(0f, 0f, -40f);
            GreenPurple.SetActive(true);    
        }
        else
        {
            handle.transform.rotation = Quaternion.Euler(0f, 0f, 70f);
            RedBlue.SetActive(true);
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isGP)
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

                    isGP = !isGP;
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

                    isGP = !isGP;
                }
            }
        }

    }
}
