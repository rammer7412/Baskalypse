using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    protected UIManager() { }

    [Header("Color Buttons")]
    [SerializeField] public Button redButton;
    [SerializeField] public Button blueButton;
    [SerializeField] public Button greenButton;
    [SerializeField] public Button purpleButton;

    [Header("UI Elements")]
    [SerializeField] public GameObject failPanel;
    [SerializeField] public GameObject successPanel;

}
