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
        RedButton   = UIManager.Instance.redButton;
        BlueButton  = UIManager.Instance.blueButton;
        GreenButton = UIManager.Instance.greenButton;
        PurpleButton= UIManager.Instance.purpleButton;
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
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(true); // ★ 추가: 이미지 On
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            blueIsMoved = !blueIsMoved;
        }
        else
        {
            foreach (var bar in blueBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(false); // ★ 추가: 이미지 Off
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            blueIsMoved = !blueIsMoved;
        }
        StartCoroutine("DisableBlueButton");
    }

    public void RedOpen()
    {
        if (!redIsMoved)
        {
            foreach (var bar in redBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(true); // ★
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            redIsMoved = !redIsMoved;
        }
        else
        {
            foreach (var bar in redBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(false); // ★
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            redIsMoved = !redIsMoved;
        }
        StartCoroutine("DisableRedButton");
    }

    public void GreenOpen()
    {
        if (!greenIsMoved)
        {
            foreach (var bar in greenBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(true); // ★
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            greenIsMoved = !greenIsMoved;
        }
        else
        {
            foreach (var bar in greenBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(false); // ★
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            greenIsMoved = !greenIsMoved;
        }
        StartCoroutine("DisableGreenButton");
    }

    public void PurpleOpen()
    {
        if (!purpleIsMoved)
        {
            foreach (var bar in purpleBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(true); // ★
                bar.transform.DOMove(g.movedPos, g.openSpeed);
            }
            purpleIsMoved = !purpleIsMoved;
        }
        else
        {
            foreach (var bar in purpleBars)
            {
                var g = bar.GetComponent<Bar>();
                if (g == null) continue;
                g.SetState(false); // ★
                bar.transform.DOMove(g.initialPos, g.openSpeed);
            }
            purpleIsMoved = !purpleIsMoved;
        }
        StartCoroutine("DisablePurpleButton");
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
