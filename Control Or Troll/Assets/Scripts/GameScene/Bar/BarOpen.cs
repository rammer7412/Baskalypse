using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class GateOpen : MonoBehaviour
{
    public GameObject[] blueBars;
    public GameObject[] redBars;
    public GameObject[] greenBars;
    public GameObject[] purpleBars;

    Button RedButton;
    Button BlueButton;
    Button GreenButton;
    Button PurpleButton;

    void Awake()
    {
        RedButton = UIManager.Instance.redButton;
        BlueButton = UIManager.Instance.blueButton;
        GreenButton = UIManager.Instance.greenButton;
        PurpleButton = UIManager.Instance.purpleButton;
    }

    bool redIsMoved = false;
    bool blueIsMoved = false;
    bool greenIsMoved = false;
    bool purpleIsMoved = false;

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
            foreach (var bar in blueBars)
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

    public void GreenOpen()
    {

        if (greenIsMoved)
        {
            foreach (var bar in greenBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y - g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x - g.openRange, g.openSpeed);

            }
            greenIsMoved = !greenIsMoved;
            StartCoroutine("DisableGreenButton");
        }
        else
        {
            foreach (var bar in greenBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y + g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x + g.openRange, g.openSpeed);

            }
            greenIsMoved = !greenIsMoved;
            StartCoroutine("DisableGreenButton");
        }

    }

    public void PurpleOpen()
    {

        if (purpleIsMoved)
        {
            foreach (var bar in purpleBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y - g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x - g.openRange, g.openSpeed);

            }
            purpleIsMoved = !purpleIsMoved;
            StartCoroutine("DisablePurpleButton");
        }
        else
        {
            foreach (var bar in purpleBars)
            {
                Bar g = bar.GetComponent<Bar>();
                if (g.isUpdown) bar.transform.DOMoveY(bar.transform.position.y + g.openRange, g.openSpeed);
                else bar.transform.DOMoveX(bar.transform.position.x + g.openRange, g.openSpeed);

            }
            purpleIsMoved = !purpleIsMoved;
            StartCoroutine("DisablePurpleButton");
        }

    }



    IEnumerator DisableBlueButton()
    {
        BlueButton.interactable = false;
        yield return new WaitForSeconds(2f);
        BlueButton.interactable = true;
    }

    IEnumerator DisableRedButton()
    {
        RedButton.interactable = false;
        yield return new WaitForSeconds(2f);
        RedButton.interactable = true;
    }

    IEnumerator DisableGreenButton()
    {
        GreenButton.interactable = false;
        yield return new WaitForSeconds(2f);
        GreenButton.interactable = true;
    }

    IEnumerator DisablePurpleButton()
    {
        GreenButton.interactable = false;
        yield return new WaitForSeconds(2f);
        GreenButton.interactable = true;
    }
}
