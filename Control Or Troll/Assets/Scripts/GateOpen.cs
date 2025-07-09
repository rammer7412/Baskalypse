using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class GateOpen : MonoBehaviour
{
    public GameObject[] blueGates;
    public GameObject[] redGates;

    public Button blueButton;
    public Button redButton;

    bool redIsMoved = false;
    bool blueIsMoved = false;

    public void BlueOpen()
    {

        if (blueIsMoved)
        {
            foreach (var gate in blueGates)
            {
                Gate g = gate.GetComponent<Gate>();
                if (g.isUpdown) gate.transform.DOMoveY(gate.transform.position.y - g.openRange, g.openSpeed);
                else gate.transform.DOMoveX(gate.transform.position.x - g.openRange, g.openSpeed);
            }
            blueIsMoved = !blueIsMoved;
            StartCoroutine("DisableBlueButton");
        }
        else
        {
            foreach (var gate in blueGates)
            {
                Gate g = gate.GetComponent<Gate>();
                if (g.isUpdown) gate.transform.DOMoveY(gate.transform.position.y + g.openRange, g.openSpeed);
                else gate.transform.DOMoveX(gate.transform.position.x + g.openRange, g.openSpeed);

            }
            blueIsMoved = !blueIsMoved;
            StartCoroutine("DisableBlueButton");
        }

    }

    public void RedOpen()
    {

        if (redIsMoved)
        {
            foreach (var gate in redGates)
            {
                Gate g = gate.GetComponent<Gate>();
                if (g.isUpdown) gate.transform.DOMoveY(gate.transform.position.y - g.openRange, g.openSpeed);
                else gate.transform.DOMoveX(gate.transform.position.x - g.openRange, g.openSpeed);

            }
            redIsMoved = !redIsMoved;
            StartCoroutine("DisableRedButton");
        }
        else
        {
            foreach (var gate in redGates)
            {
                Gate g = gate.GetComponent<Gate>();
                if (g.isUpdown) gate.transform.DOMoveY(gate.transform.position.y + g.openRange, g.openSpeed);
                else gate.transform.DOMoveX(gate.transform.position.x + g.openRange, g.openSpeed);

            }
            redIsMoved = !redIsMoved;
            StartCoroutine("DisableRedButton");
        }

    }



    IEnumerator DisableBlueButton()
    {
        blueButton.interactable = false;
        yield return new WaitForSeconds(2f);
        blueButton.interactable = true;
    }

    IEnumerator DisableRedButton()
    {
        redButton.interactable = false;
        yield return new WaitForSeconds(2f);
        redButton.interactable = true;
    }
}
