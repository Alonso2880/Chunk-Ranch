using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inicio : MonoBehaviour
{
    public Button jugar;
    public Button instrucciones;
    private Canvas m;
    public TextMeshProUGUI uno;
    public TextMeshProUGUI dos;
    void Start()
    {
        jugar.onClick.AddListener(() => Jugar());
        instrucciones.onClick.AddListener(() => Instrucciones());
        Time.timeScale = 0;
        m = this.GetComponent<Canvas>();
        
        dos.enabled = false;

    }

    private void Jugar()
    {
        Time.timeScale = 1;
        m.enabled = false;

    }

    private void Instrucciones()
    {
        instrucciones.enabled = false;
        uno.enabled = false;
        dos.enabled = true;
    }
    
    void Update()
    {
        
    }
}
