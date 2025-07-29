using UnityEngine;
using UnityEngine.SceneManagement;

public class FailRestartButton : MonoBehaviour
{
    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Debug.Log($"다시 시작 버튼 클릭됨!: {currentScene}, {currentScene.name}");
    }
}
