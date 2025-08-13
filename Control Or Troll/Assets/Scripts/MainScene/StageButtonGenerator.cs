using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class StageButtonGenerator : MonoBehaviour
{
    public GameObject stageButtonPrefab;
    public Transform buttonGridParent;
    public int stageCount = 5;

    void Start()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        string[] parts = currentSceneName.Split('_');

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
                if (currentSceneName.StartsWith("Stage_") && parts.Length == 2)
                {
                    loader.stageName = $"Stage_{parts[1]}_{i}";
                }
                else if (currentSceneName == "PickChapterScene")
                {
                    loader.stageName = $"Stage_{i}";
                }
                Debug.Log($"버튼 {i}에 할당된 stageName: {loader.stageName}");

                Button btn = newButton.GetComponent<Button>();
                if (btn != null)
                    btn.onClick.AddListener(loader.LoadStage);
            }
        }
    }
}
