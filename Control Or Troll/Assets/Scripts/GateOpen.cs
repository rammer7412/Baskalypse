using DG.Tweening;
using UnityEngine;


public class GateOpen : MonoBehaviour
{
    public bool isRed;
    bool isMoved = false;

    public void BlueOpen()
    {
        if (!isRed)
        {
            if (isMoved)
            {
                transform.DOMoveY(transform.position.y - 4f, 2f);
                isMoved = !isMoved;

            }
            else
            {
                transform.DOMoveY(transform.position.y + 4f, 2f);
                isMoved = !isMoved;
            }
        }
    }
    
    public void RedOpen()
    {
        if (isRed)
        {
            if (isMoved)
            {
                transform.DOMoveY(transform.position.y - 4f, 2f);
                isMoved = !isMoved;
                
            }
            else
            {
                transform.DOMoveY(transform.position.y + 4f, 2f);
                isMoved = !isMoved;
            }
        }
    }
}
