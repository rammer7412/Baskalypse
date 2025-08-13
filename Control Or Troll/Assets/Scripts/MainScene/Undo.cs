using UnityEngine;
using UnityEngine.SceneManagement;

public class Undo : MonoBehaviour
{
    public void UndoOn()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "PickChapterScene")
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (sceneName == "PickChapterScene")
        {
            SceneManager.LoadScene("MainScene");
        }
        if (sceneName.StartsWith("Stage_"))
        {
            string[] parts = sceneName.Split('_');

            if (parts.Length == 2)
            {
                // 예: Stage_1
                int stageNumber = int.Parse(parts[1]);
                Debug.Log($"단일 스테이지: {stageNumber}");
                SceneManager.LoadScene("PickChapterScene");
            }
            else if (parts.Length == 3)
            {
                // 예: Stage_2_1
                int chapter = int.Parse(parts[1]);
                int level = int.Parse(parts[2]);
                Debug.Log($"챕터 스테이지: 챕터 {chapter}, 레벨 {level}");
                SceneManager.LoadScene($"Stage_{chapter}");
            }
            else
            {
                Debug.LogWarning("Stage 패턴이 예상과 다릅니다.");
            }
        }
    }
}
