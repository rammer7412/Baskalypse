using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    [SerializeField] GameObject leverBar;
    [SerializeField] GameObject RedBlue;
    [SerializeField] GameObject GreenPurple;

    GameObject RedButton;
    GameObject BlueButton;
    GameObject GreenButton;
    GameObject PurpleButton;

    void Awake()
    {
        RedButton = UIManager.Instance.redButton.gameObject;
        BlueButton = UIManager.Instance.blueButton.gameObject;
        GreenButton = UIManager.Instance.greenButton.gameObject;
        PurpleButton = UIManager.Instance.purpleButton.gameObject;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ball")
        {
            leverBar.transform.DORotate(new Vector3(0f, 0f, -60f), 1f);
            RedBlue.SetActive(false);
            GreenPurple.SetActive(true);

            RedButton.SetActive(false);
            BlueButton.SetActive(false);
            GreenButton.SetActive(true);
            PurpleButton.SetActive(true);
        }

    }
}
