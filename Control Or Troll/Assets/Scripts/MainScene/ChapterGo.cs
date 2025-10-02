using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterGo : MonoBehaviour
{
    [Header("이 버튼이 이동할 챕터 씬 이름")]
    public string chapterName;

    private void Awake()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(GoToChapter);
        }
    }

    public void GoToChapter()
    {
        if (!string.IsNullOrEmpty(chapterName))
        {
            Debug.Log($"챕터로 이동: {chapterName}");
            SceneManager.LoadScene(chapterName);
        }
        else
        {
            Debug.LogWarning("ChapterGo: chapterName이 비어있습니다.");
        }
    }
}
