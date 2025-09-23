using UnityEngine;

public class SceneBGMStarter : MonoBehaviour
{
    [SerializeField] private AudioClip sceneBGM;
    [Tooltip("씬 진입 시 기존 재생을 먼저 멈춘 뒤 새 클립으로 강제 교체합니다.")]
    [SerializeField] private bool forceSwitch = true;

    [Tooltip("이 씬에서는 BGM을 끕니다(새 클립도 틀지 않음).")]
    [SerializeField] private bool stopMusic = false;

    private void Start()
    {
        if (BGMManager.Instance == null) return;

        if (stopMusic)
        {
            BGMManager.Instance.StopBGM();
            return;
        }

        if (sceneBGM != null)
        {
            if (forceSwitch)
            {
                BGMManager.Instance.StopBGM();
            }
            BGMManager.Instance.PlayBGM(sceneBGM);
        }
    }
}
