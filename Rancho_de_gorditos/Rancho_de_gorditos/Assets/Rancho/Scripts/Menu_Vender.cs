using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu_Vender : MonoBehaviour
{
    private GameObject menu_vender;
    private Canvas canvasV;
    public Button salir;
    public Button v_huevos, v_carne, v_leche, v_lana;
    private GameObject tienda;
    [HideInInspector] public GameObject coli;
    public TMP_InputField inputCantidad, inutCantidadCarne, inputCantidadLeche, inputCantidadLana;
    public GameObject buzon;
    void Start()
    {
        v_huevos.onClick.AddListener(OnClickVender);
        v_carne.onClick.AddListener(VenderC);
        v_leche.onClick.AddListener(VenderL);
        v_lana.onClick.AddListener(VenderLa);
        salir.onClick.AddListener(CerrarMenu);

        tienda = GameObject.Find("TiendaVender");

        menu_vender = this.gameObject;
        canvasV = this.GetComponent<Canvas>();
        canvasV.enabled = false;
        inputCantidad.enabled = false;  

        v_carne.gameObject.SetActive(false);
        v_leche.gameObject.SetActive(false);
        v_lana.gameObject.SetActive(false);
        inutCantidadCarne.gameObject.SetActive(false);
        inputCantidadLeche.gameObject.SetActive(false);
        inputCantidadLana.gameObject.SetActive(false);
    }

    public void OnClickVender()
    {
        int cantidad;
        if(!int.TryParse(inputCantidad.text, out cantidad)|| cantidad <= 0)
        {
            Debug.LogWarning("Introduce un número válido de huevos");
            return;
        }

        Tienda t = tienda.GetComponent<Tienda>();
        t.Huevo(cantidad);

        CerrarMenu();
    }

    public void VenderC()
    {
        int cantidad;
        if (!int.TryParse(inutCantidadCarne.text, out cantidad) || cantidad <= 0)
        {
            Debug.LogWarning("Introduce un número válido de carne");
            return;
        }

        Tienda t = tienda.GetComponent<Tienda>();
        t.Carne(cantidad);

        CerrarMenu();
    }

    public void VenderL()
    {
        int cantidad;
        if (!int.TryParse(inputCantidadLeche.text, out cantidad) || cantidad <= 0)
        {
            Debug.LogWarning("Introduce un número válido de leche");
            return;
        }

        Tienda t = tienda.GetComponent<Tienda>();
        t.Leche(cantidad);

        CerrarMenu();
    }

    public void VenderLa()
    {
        int cantidad;
        if (!int.TryParse(inputCantidadLana.text, out cantidad) || cantidad <= 0)
        {
            Debug.LogWarning("Introduce un número válido de lana");
            return;
        }

        Tienda t = tienda.GetComponent<Tienda>();
        t.Lana(cantidad);

        CerrarMenu();
    }

    public void AbrirMenu()
    {
        BuzónUI b = buzon.GetComponent<BuzónUI>();

        canvasV.enabled = true;
        Time.timeScale = 0; 
        inputCantidad.enabled = true;

        if (b.E1 && !b.E2 && !b.E3)
        {
            v_carne.gameObject.SetActive(true);
            v_leche.gameObject.SetActive(false);
            v_lana.gameObject.SetActive(false);
            inutCantidadCarne.gameObject.SetActive(true);
            inputCantidadLeche.gameObject.SetActive(false);
            inputCantidadLana.gameObject.SetActive(false);
        }

        if (b.E1 && b.E2 && !b.E3)
        {
            v_carne.gameObject.SetActive(true);
            v_leche.gameObject.SetActive(true);
            v_lana.gameObject.SetActive(false);
            inutCantidadCarne.gameObject.SetActive(true);
            inputCantidadLeche.gameObject.SetActive(true);
            inputCantidadLana.gameObject.SetActive(false);
        }

        if (b.E1 && b.E2 && b.EM)
        {
            v_carne.gameObject.SetActive(true);
            v_leche.gameObject.SetActive(true);
            v_lana.gameObject.SetActive(true);
            inutCantidadCarne.gameObject.SetActive(true);
            inputCantidadLeche.gameObject.SetActive(true);
            inputCantidadLana.gameObject.SetActive(true);
        }
    }
    private void CerrarMenu()
    {
        canvasV.enabled = false;
        Time.timeScale = 1;
        inputCantidad.enabled = false;
    }

    void Update()
    {
        
    }
}
