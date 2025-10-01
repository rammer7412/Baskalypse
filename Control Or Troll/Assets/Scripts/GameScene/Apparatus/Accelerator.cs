using System.Collections;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField] private float Force = 5f;

    [Header("Images")]
    [SerializeField] private GameObject image1; // 평소 보여줄 이미지
    [SerializeField] private GameObject image2; // 닿았을 때 보여줄 이미지

    private bool isSwitching = false;

    void Start()
    {
        // 초기 상태: 1번만 켜기
        image1.SetActive(true);
        image2.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            collision.GetComponent<Rigidbody2D>().AddForceX(Force, ForceMode2D.Force);

            // 닿는 순간 1초간 이미지 교체
            if (!isSwitching)
                StartCoroutine(SwitchImage());
        }
    }

    IEnumerator SwitchImage()
    {
        isSwitching = true;
        image1.SetActive(false);
        image2.SetActive(true);

        yield return new WaitForSeconds(1f);

        image1.SetActive(true);
        image2.SetActive(false);
        isSwitching = false;
    }
}
