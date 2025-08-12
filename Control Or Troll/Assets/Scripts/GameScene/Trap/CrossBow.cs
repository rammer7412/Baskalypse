using UnityEngine;

public class CrossBow : MonoBehaviour
{
    [SerializeField] private GameObject Arrow;
    [SerializeField] private float arrowSpeed = 15f;
    [SerializeField] private float fireCoolTime = 3;
    [SerializeField] private bool isDirLeft = true;



    private void Start()
    {
        InvokeRepeating(nameof(Fire), 0.1f, fireCoolTime);
    }

    private void Fire()
    {
        var shot = Instantiate(Arrow, transform);

        shot.transform.GetComponent<Rigidbody2D>().AddForceX(isDirLeft ? -1 * arrowSpeed : arrowSpeed, ForceMode2D.Impulse);
    }


}
