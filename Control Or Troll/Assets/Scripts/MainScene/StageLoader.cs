using UnityEngine;
using UnityEngine.SceneManagement;

public class StageLoader : MonoBehaviour
{
    public string stageName;

    public void LoadStage()
    {
        Debug.Log($"스테이지 로딩: {stageName}");
        SceneManager.LoadScene(stageName);
    }
}
