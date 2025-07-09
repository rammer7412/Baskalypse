using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class GateOpen : MonoBehaviour
{
    public GameObject[] blueBars;
    public GameObject[] redBars;

    public Button blueButton;
    public Button redButton;

    bool redIsMoved = false;
    bool blueIsMoved = false;

    public void BlueOpen()
    {

        if (blueIsMoved)
        {
            foreach (var bar in blueBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y - g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x - g.openRange, g.openSpeed);
            }
            blueIsMoved = !blueIsMoved;
            StartCoroutine("DisableBlueButton");
        }
        else
        {
            foreach (var  bar in blueBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y + g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x + g.openRange, g.openSpeed);

            }
            blueIsMoved = !blueIsMoved;
            StartCoroutine("DisableBlueButton");
        }

    }

    public void RedOpen()
    {

        if (redIsMoved)
        {
            foreach (var bar in redBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y - g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x - g.openRange, g.openSpeed);

            }
            redIsMoved = !redIsMoved;
            StartCoroutine("DisableRedButton");
        }
        else
        {
            foreach (var bar in redBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y + g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x + g.openRange, g.openSpeed);

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
