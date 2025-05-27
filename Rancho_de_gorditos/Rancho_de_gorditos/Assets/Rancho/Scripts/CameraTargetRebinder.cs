using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Cinemachine; 

public class CameraTargetRebinder : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Buscamos el Player persistente por Tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // Buscamos la Virtual Camera que hay en la escena nueva
        CinemachineVirtualCameraBase vcam = Object.FindAnyObjectByType<CinemachineVirtualCameraBase>();
        if (player != null && vcam != null)
        {
            vcam.Follow = player.transform;
            vcam.LookAt = player.transform; // si también la usas para apuntar
        }
    }
}

