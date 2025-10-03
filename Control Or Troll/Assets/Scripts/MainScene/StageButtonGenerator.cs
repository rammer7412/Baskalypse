using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButtonGenerator : MonoBehaviour
{
    [Header("프리팹 & 레이아웃")]
    public GameObject stageButtonPrefab;
    public Transform buttonGridParent;
    public int stageCount = 5;

    [Header("스테이지별 버튼 이미지 (1번 -> index 0)")]
    public Sprite[] stageSprites;
    public bool setNativeSize = false; // 필요 시 원본 크기로 버튼 이미지 맞추기

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string[] parts = currentSceneName.Split('_');

        for (int i = 1; i <= stageCount; i++)
        {
            GameObject newButton = Instantiate(stageButtonPrefab, buttonGridParent);
            newButton.SetActive(true);

            // --- 텍스트 제거(있어도 비활성화) ---
            // 프리팹에 남아있는 TMP/Text가 있다면 꺼두기 (선택)
            var tmp = newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>(true);
            if (tmp != null) tmp.gameObject.SetActive(false);

            // --- 이미지 적용 ---
            Image img = newButton.GetComponent<Image>();
            if (img == null)
                img = newButton.GetComponentInChildren<Image>(includeInactive: true);

            int spriteIndex = i - 1; // 1-based -> 0-based
            if (img != null)
            {
                if (stageSprites != null && spriteIndex < stageSprites.Length && stageSprites[spriteIndex] != null)
                {
                    img.sprite = stageSprites[spriteIndex];
                    if (setNativeSize) img.SetNativeSize();
                }
                else
                {
                    Debug.LogWarning($"[StageButtonGenerator] 스프라이트가 비었거나 부족합니다. i={i}, index={spriteIndex}, spritesLen={(stageSprites==null?0:stageSprites.Length)}");
                }
            }
            else
            {
                Debug.LogWarning("[StageButtonGenerator] Image 컴포넌트를 찾지 못했습니다. 프리팹에 Image가 있는지 확인하세요.");
            }

            // --- stageName 설정 & 클릭 연결(기존 로직 유지) ---
            StageLoader loader = newButton.GetComponent<StageLoader>();
            if (loader != null)
            {
                if (currentSceneName.StartsWith("Stage_") && parts.Length == 2)
                {
                    loader.stageName = $"Stage_{parts[1]}_{i}";
                }
                else if (currentSceneName == "PickChapterScene")
                {
                    loader.stageName = $"Stage_{i}";
                }
                // Debug.Log($"버튼 {i}에 할당된 stageName: {loader.stageName}");

                Button btn = newButton.GetComponent<Button>();
                if (btn != null)
                    btn.onClick.AddListener(loader.LoadStage);
            }
        }
    }
}
