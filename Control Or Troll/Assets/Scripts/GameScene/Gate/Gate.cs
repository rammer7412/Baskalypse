using UnityEngine;

public enum GateType
{
    Normal, Iron, Gravity
};

public class Gate : MonoBehaviour
{
    public GateType gateType;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            if (gateType == GateType.Normal) Ball.Instance.ChangeBall("Normal");
            else if (gateType == GateType.Iron) Ball.Instance.ChangeBall("Iron");
            else if (gateType == GateType.Gravity) Ball.Instance.ChangeBall("Gravity");
        }
    }
}
