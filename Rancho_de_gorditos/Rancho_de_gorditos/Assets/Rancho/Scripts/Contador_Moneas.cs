using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Contador_Moneas : MonoBehaviour
{
    public TextMeshProUGUI Cont_monedas;
    public int monedas = 0;
    GameObject tienda;
    void Start()
    {
        tienda = GameObject.FindGameObjectWithTag("Tienda");
        Tienda tiendaScript = tienda.GetComponent<Tienda>();
        ActualizarMonedas();
    }

    
    void Update()
    {
        ActualizarMonedas();
    }
    private void ActualizarMonedas()
    {
        Cont_monedas.text = monedas.ToString();
    }
}
