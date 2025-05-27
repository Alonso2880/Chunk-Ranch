using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class felicidades : MonoBehaviour
{
    [HideInInspector] public bool ya = false;
    private Canvas canvasM;
    public Button VA;
    void Start()
    {
        
        canvasM = this.GetComponent<Canvas>();
        canvasM.enabled = false;
        VA.onClick.AddListener(() => Reiniciar());

    }

    private void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ya = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (ya == true)
        {
            canvasM.enabled = true;
            Time.timeScale = 0;
        }
    }
}
