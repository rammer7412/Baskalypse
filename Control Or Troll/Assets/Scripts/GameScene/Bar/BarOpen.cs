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

    private Button RedButton;
    private Button BlueButton;
    private Button GreenButton;
    private Button PurpleButton;

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

        if (!blueIsMoved)
        {
            foreach (var bar in blueBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            blueIsMoved = !blueIsMoved;
            StartCoroutine("DisableBlueButton");
        }
        else
        {
            foreach (var bar in blueBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            blueIsMoved = !blueIsMoved;
            StartCoroutine("DisableBlueButton");
        }

    }

    public void RedOpen()
    {
        if (!redIsMoved)
        {
            foreach (var bar in redBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            redIsMoved = !redIsMoved;
            StartCoroutine("DisableRedButton");
        }
        else
        {
            foreach (var bar in redBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            redIsMoved = !redIsMoved;
            StartCoroutine("DisableRedButton");
        }
    }

    public void GreenOpen()
    {

        if (!greenIsMoved)
        {
            foreach (var bar in greenBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            greenIsMoved = !greenIsMoved;
            StartCoroutine("DisableGreenButton");
        }
        else
        {
            foreach (var bar in greenBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            greenIsMoved = !greenIsMoved;
            StartCoroutine("DisableGreenButton");
        }

    }

    public void PurpleOpen()
    {

        if (!purpleIsMoved)
        {
            foreach (var bar in purpleBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            purpleIsMoved = !purpleIsMoved;
            StartCoroutine("DisablePurpleButton");
        }
        else
        {
            foreach (var bar in purpleBars)
            {
                Bar g = bar.GetComponent<Bar>();
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            purpleIsMoved = !purpleIsMoved;
            StartCoroutine("DisablePurpleButton");
        }

    }



    IEnumerator DisableBlueButton()
    {
        BlueButton.interactable = false;
        yield return new WaitForSeconds(0.1f);
        BlueButton.interactable = true;
    }

    IEnumerator DisableRedButton()
    {
        RedButton.interactable = false;
        yield return new WaitForSeconds(0.1f);
        RedButton.interactable = true;
    }

    IEnumerator DisableGreenButton()
    {
        GreenButton.interactable = false;
        yield return new WaitForSeconds(0.1f);
        GreenButton.interactable = true;
    }

    IEnumerator DisablePurpleButton()
    {
        PurpleButton.interactable = false;
        yield return new WaitForSeconds(0.1f);
        PurpleButton.interactable = true;
    }
}
