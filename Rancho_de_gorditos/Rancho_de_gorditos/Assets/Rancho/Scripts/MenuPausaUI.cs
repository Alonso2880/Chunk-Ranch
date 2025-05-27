using UnityEngine;
using UnityEngine.UI;

public class MenuPausaUI : MonoBehaviour
{
    public Canvas c;
    public Button pausa, salir, ajustes, inventario, cartas;
    private GameObject ManuInicio, AjustesU;
    public GameObject Inventario, buzon;
    public AudioSource bosque, rancho, inic;

    [HideInInspector] public bool pausaM = false;
    void Start()
    {
        pausa.onClick.AddListener(() => opciones(1));
        salir.onClick.AddListener(()=> opciones (2));
        ajustes.onClick.AddListener(()=> opciones(3));
        inventario.onClick.AddListener(() => invent());
        cartas.onClick.AddListener(() => cart());
        c.enabled = false;

        ManuInicio = GameObject.Find("MenuInicio");
        AjustesU = GameObject.Find("AjustesIU");
    }

    private void invent()
    {
        InventoryUI i = Inventario.GetComponent<InventoryUI>();
        c.enabled = false;
        i.c.enabled = true;
    }

    private void cart()
    {
        BuzónUI b = buzon.GetComponent<BuzónUI>();
        c.enabled = false;
        b.abrir();
    }



    private void opciones (int n)
    {
        MenuInicio m = ManuInicio.GetComponent<MenuInicio>();
        AjustesUI u = AjustesU.GetComponent<AjustesUI>();
        switch (n)
        {
            case 1:
                c.enabled = false;
                Time.timeScale = 1;
                break;

            case 2:
                c.enabled = false;
                m.Menu.enabled = true;
                bosque.mute = true;
                rancho.mute = true;
                inic.mute = false;
                break;
            case 3:
                c.enabled = false;
                u.inicio();
                break;
        }
    }
   
    public void inicio()
    {
        c.enabled = true;
        Time.timeScale = 0;
    }

    void Update()
    {
        if(AjustesU != null)
        {
            //Debug.Log("H");
        }
    }
}
