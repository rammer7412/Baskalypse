using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    public string stageName;
    public string chapterName;

    public void LoadStage()
    {
        Debug.Log($"스테이지 로딩: {stageName}");
        SceneManager.LoadScene(stageName);
    }
    public void LoadChapter()
    {
        Debug.Log($"Chapter 로딩: {chapterName}");
        SceneManager.LoadScene(chapterName);
    }
}
