using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();

    public static T Instance
    {
        get
        {
            // 어플리케이션이 종료될 때 instance를 호출하면 null을 반환하도록 방지
            // (이 코드는 필수는 아니지만 안정성을 위해 추가)
            if (applicationIsQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed on application quit. Won't create again - returning null.");
                return null;
            }

            lock (_lock)
            {
                // 인스턴스가 없다면 씬에서 찾아본다.
                if (_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();

                    // 씬에도 없다면 경고 메시지 출력 (자동으로 생성하지 않음)
                    if (_instance == null)
                    {
                        Debug.LogError($"[Singleton] An instance of {typeof(T)} is needed in the scene, but there is none.");
                    }
                }
                return _instance;
            }
        }
    }

    // 중복 생성을 방지하고, DontDestroyOnLoad를 처리하는 Awake
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            // 이 인스턴스를 싱글톤으로 설정
            _instance = this as T;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_instance != this)
        {
            // 이미 인스턴스가 존재하면, 이 오브젝트는 파괴
            Debug.Log($"[Singleton] Duplicate instance of {typeof(T).Name} found. Destroying the new one.");
            Destroy(gameObject);
        }
    }

    private static bool applicationIsQuitting = false;

    // 어플리케이션 종료 시 플래그 설정
    protected virtual void OnApplicationQuit()
    {
        applicationIsQuitting = true;
    }
}