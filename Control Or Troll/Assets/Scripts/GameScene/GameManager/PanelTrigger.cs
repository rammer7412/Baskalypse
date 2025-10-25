using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelTrigger : MonoBehaviour
{
    public string ParseScene(string mode)
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (!sceneName.StartsWith("Stage_"))
            return null;

        string[] parts = sceneName.Split('_');

        switch (mode)
        {
            case "restart":
                return sceneName;

            case "home":
                return "MainScene";

            case "next":
                if (parts.Length == 2)
                {
                    int stage = int.Parse(parts[1]);
                    return $"Stage_{stage + 1}";
                }
                else if (parts.Length == 3)
                {
                    int chapter = int.Parse(parts[1]);
                    int level = int.Parse(parts[2]);
                    return $"Stage_{chapter}_{level + 1}";
                }
                break;

            case "chapter":
                if (parts.Length >= 2)
                    return parts[1]; // "2" from "Stage_2_1"

                break;

            default:
                Debug.LogWarning("지원하지 않는 mode입니다: " + mode);
                break;
        }

        return null;
    }

    public void RestartButtonOn()
    {
        string currentScene = ParseScene("restart");
        if (!string.IsNullOrEmpty(currentScene))
        {
            SceneManager.LoadScene(currentScene);
        }
    }

    public void HomeButtonOn()
    {
        string currentScene = ParseScene("home");
        if (!string.IsNullOrEmpty(currentScene))
        {
            SceneManager.LoadScene(currentScene);
        }
    }
    public void NextButtonOn()
    {
        string currentScene = ParseScene("next");
        if (!string.IsNullOrEmpty(currentScene))
        {
            SceneManager.LoadScene(currentScene);
        }
    }
    public void ChapterButtonOn()
    {
        string chapterScene = ParseScene("chapter");
        if (!string.IsNullOrEmpty(chapterScene))
        {
            SceneManager.LoadScene("Stage_" + chapterScene);
        }
    }
}
