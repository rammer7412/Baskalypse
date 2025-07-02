using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class RedGateOpen : MonoBehaviour
{
    bool nowUp = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void red_gateUp()
    {
        if (!nowUp)
        {
            transform.DOMoveY(transform.position.y + 2f, 2f);
            nowUp = !nowUp;
        }
        else
        {
            transform.DOMoveY(transform.position.y - 2f, 2f);
            nowUp = !nowUp;
        }
    }
}
