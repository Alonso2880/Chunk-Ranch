using UnityEngine;
using UnityEngine.UI;

public class CasaUI : MonoBehaviour
{
    public Button Si, No;
    private GameObject Casa;
    public Canvas c;
    
    void Start()
    {
        Si.onClick.AddListener(() => SI());
        No.onClick.AddListener(() => NO());
        Casa = GameObject.Find("CasaBrujita");
        c.enabled = false;
    }

    public void abrir()
    {
        c.enabled = true;
        Time.timeScale = 0;
    }

    private void cerrar()
    {
        c.enabled = false;
        Time.timeScale = 1;
    }
    private void SI()
    {
        casa c = Casa.GetComponent<casa>();
        Debug.Log("Has cambiado de día");
        c.dia++;
        cerrar();
    }

    private void NO()
    {
        cerrar();
    }


    void Update()
    {
        
    }
}
