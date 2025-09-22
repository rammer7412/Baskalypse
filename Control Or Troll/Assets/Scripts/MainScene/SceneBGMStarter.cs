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

        // 이 씬에서 BGM을 끄기만 하는 경우
        if (stopMusic)
        {
            BGMManager.Instance.StopBGM();
            return;
        }

        // 새 음악 지정된 경우
        if (sceneBGM != null)
        {
            if (forceSwitch)
            {
                // 진행 중인 음악이 무엇이든 일단 정지 후 새 클립으로 교체
                BGMManager.Instance.StopBGM();
            }
            // 같은 클립이라도 Stop 후 Play로 처음부터 재생됨
            BGMManager.Instance.PlayBGM(sceneBGM);
        }
        // sceneBGM이 비어 있으면 아무것도 하지 않음(이전 곡 유지)
    }
}
