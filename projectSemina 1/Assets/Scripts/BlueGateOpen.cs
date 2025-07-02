using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BlueGateOpen : MonoBehaviour
{
    bool nowUp = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void blue_gateMove()
    {
        if (!nowUp)
        {
            transform.DOLocalMoveY(transform.position.y + 2f, 2f);
            nowUp = !nowUp;
        }
        else
        {
            transform.DOMoveY(transform.position.y - 2f, 2f);
            nowUp = !nowUp;
        }
    }
}
