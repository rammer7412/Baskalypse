using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("게임 시작 버튼 클릭!");
        SceneManager.LoadScene("Stage");
    }
}
