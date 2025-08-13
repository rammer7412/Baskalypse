using UnityEngine;
using UnityEngine.SceneManagement;
public class ChapterButtonTrigger : MonoBehaviour
{
    string chapterName = SceneManager.GetActiveScene().name;
    public void ChapterButtonOn()
    {
        Debug.Log($"Chapter 로딩: {chapterName}");
        SceneManager.LoadScene(chapterName);
    }
}
