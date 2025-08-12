using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageButtonGenerator : MonoBehaviour
{
    public GameObject stageButtonPrefab;
    public Transform buttonGridParent;
    public int stageCount = 17;

    void Start()
    {
        for (int i = 1; i <= stageCount; i++)
        {
            GameObject newButton = Instantiate(stageButtonPrefab, buttonGridParent);
            newButton.SetActive(true);

            // 텍스트 설정
            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
                buttonText.text = i.ToString();

            // stageName 설정
            StageLoader loader = newButton.GetComponent<StageLoader>();
            if (loader != null)
            {
                loader.stageName = $"Stage{i}";
                Debug.Log($"버튼 {i}에 할당된 stageName: {loader.stageName}");

                // ✅ 버튼 클릭 이벤트 연결
                Button btn = newButton.GetComponent<Button>();
                if (btn != null)
                    btn.onClick.AddListener(loader.LoadStage);
            }
        }
    }
}
