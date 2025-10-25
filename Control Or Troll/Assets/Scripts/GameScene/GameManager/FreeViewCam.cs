using UnityEngine;
using UnityEngine.InputSystem;


public class FreeViewCam : MonoBehaviour
{
    [SerializeField] private GameObject cinemachineMainVirtualCamera;
    [SerializeField] private GameObject cinemachineFreeVirtualCamera;

    public bool isFreeView = false;
    private bool isDragging = false;
    private Vector3 dragWorldStart;

    public GameObject failPanel;
    public GameObject inGameRestartBtn;


    void Start()
    {
        if (isFreeView) EnterFreeMode();
    }

    public void EnterFreeMode()
    {
        if (isFreeView) return;
        failPanel.SetActive(false);
        inGameRestartBtn.SetActive(true);
        cinemachineMainVirtualCamera.SetActive(false);
        isFreeView = true;
        isDragging = false;
        Ball.Instance.gameObject.SetActive(false);
    }

    public void ExitFreeMode()
    {
        if (!isFreeView) return;
        cinemachineMainVirtualCamera.SetActive(true);
        isFreeView = false;
        isDragging = false;
    }

    void Update()
    {
        if (!isFreeView) return;

        HandleDrag();
    }

    private void HandleDrag()
    {
        // 입력 상태
        bool down = GetPointerDown();
        bool held = GetPointerHeld();
        bool up = GetPointerUp();

        if (down)
        {
            isDragging = true;
            dragWorldStart = ScreenToWorldOnPlane(GetPointerPosition());
        }
        else if (isDragging && held)
        {
            Vector3 currentWorld = ScreenToWorldOnPlane(GetPointerPosition());
            Vector3 delta = dragWorldStart - currentWorld; 
            Vector3 newPos = cinemachineFreeVirtualCamera.transform.position + delta;

            cinemachineFreeVirtualCamera.transform.position = newPos;
        }
        else if (up)
        {
            isDragging = false;
        }
    }

    private Vector3 ScreenToWorldOnPlane(Vector2 screenPos)
    {
        Camera cam = Camera.main;
        
        Vector3 ws = cam.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, Mathf.Abs(cam.transform.position.z)));
        return new Vector3(ws.x, ws.y, cinemachineFreeVirtualCamera.transform.position.z);
    }
    
    private Vector2 GetPointerPosition()
    {
        return Input.mousePosition;
    }
    private bool GetPointerDown()
    {
       return Input.GetMouseButtonDown(0);
    }
    private bool GetPointerHeld()
    {
        return Input.GetMouseButton(0);
    }
    private bool GetPointerUp()
    {
        return Input.GetMouseButtonUp(0);
    }
}
