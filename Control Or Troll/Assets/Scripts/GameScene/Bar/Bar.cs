using System;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public int openSpeed;
    public int openRange;
    public bool isUpdown;
    
    [NonSerialized] public Vector3 initialPos;
    [NonSerialized] public Vector3 movedPos;

    private void Start()
    {
        initialPos = transform.position;
        if (isUpdown) movedPos = new Vector3(transform.position.x, transform.position.y + openRange, transform.position.z);
        else movedPos = new Vector3(transform.position.x + openRange, transform.position.y, transform.position.z);
    }

}
