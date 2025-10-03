using System;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public int openSpeed;
    public int openRange;
    public bool isUpdown;

    [NonSerialized] public Vector3 initialPos;
    [NonSerialized] public Vector3 movedPos;
    [SerializeField] private bool isOn = false;
    public GameObject onObject;   // On 상태에서 보일 오브젝트
    public GameObject offObject;  // Off 상태에서 보일 오브젝트

    private void Start()
    {
        initialPos = transform.position;
        movedPos = isUpdown
            ? new Vector3(transform.position.x, transform.position.y + openRange, transform.position.z)
            : new Vector3(transform.position.x + openRange, transform.position.y, transform.position.z);

        // 초기 표시 반영
        if (onObject != null)  onObject.SetActive(isOn);
        if (offObject != null) offObject.SetActive(!isOn);
    }

    public void SetState(bool on)
    {
        if (isOn == on) return;
        isOn = on;

        // public GameObject 활용해서 전환하기
        if (onObject != null)  onObject.SetActive(isOn);
        if (offObject != null) offObject.SetActive(!isOn);
    }

}
