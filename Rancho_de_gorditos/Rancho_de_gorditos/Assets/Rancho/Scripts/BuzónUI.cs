using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuzónUI : MonoBehaviour
{
    public Button Vercarta1, Vercarta2, Vercarta3, entregar1, entregar2, entregar3, minijuego, inventario, ajustes;
    public Button salir;
    public Canvas can;
    public GameObject panel, panel2, panel3, Inventario, Pausa, miniJuego;
    private Image i, i2, i3;
    private GameObject Casa, player;
    public bool E1 = false, E2 = false, E3 = false, EM = false, V1 = false, V2 = false;
    public TextMeshProUGUI m;
    void Start()
    {
        Vercarta1.onClick.AddListener(() => Elegir(1));
        salir.onClick.AddListener(() => Elegir(2));
        Vercarta2.onClick.AddListener(() => Elegir(3));
        Vercarta3.onClick.AddListener(()=>Elegir(4));
        entregar1.onClick.AddListener(() => Entrega1());
        entregar2.onClick.AddListener(() => Entrega2());
        entregar3.onClick.AddListener(() => Entrega3());
        minijuego.onClick.AddListener(() => Minijuego());
        inventario.onClick.AddListener(() => invent());
        ajustes.onClick.AddListener(() => ajust());

        can = this.gameObject.GetComponent<Canvas>();
        can.enabled = false;

        Casa = GameObject.Find("CasaBrujita");
        player = GameObject.Find("Player");

        panel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        m.gameObject.SetActive(false);
        miniJuego.SetActive(false);
    }

    private void invent()
    {
        InventoryUI i = Inventario.GetComponent<InventoryUI>();
        can.enabled = false;
        i.c.enabled = true;
    }

    private void ajust()
    {
        MenuPausaUI m = Pausa.GetComponent<MenuPausaUI>();
        can.enabled = false;
        m.inicio();
    }


    private void Update()
    {
        casa c = Casa.GetComponent<casa>();
        Movimiento_Jugador_Rancho mo = player.GetComponent<Movimiento_Jugador_Rancho>();
        if (c.dia >= 3)
        {
            Vercarta1.gameObject.SetActive(true);
        }

       if(c.dia >= 6 && V1)
        {
            Vercarta2.gameObject.SetActive(true);
        }

        if (c.dia >= 9 && V2)
        {
            Vercarta3.gameObject.SetActive(true);
        }

        if (E3)
        {
            minijuego.gameObject.SetActive(true);
        }

        if (mo.minijuego == 6)
        {
            EM = true;
            miniJuego.SetActive(false);
            m.gameObject.SetActive(false);
            minijuego.gameObject.SetActive(false);
        }
    }
    public void Elegir(int i)
    {
        panel.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);

        switch (i)
        {
            case 1:
                if (!E1)
                {
                    Debug.Log("Carta 1");
                    can.enabled = true;
                    panel.SetActive(true);
                    entregar1.gameObject.SetActive(true);
                    entregar2.gameObject.SetActive(false);
                    entregar3.gameObject.SetActive(false);
                }
                if (E1)
                {
                    Debug.Log("Carta 1");
                    can.enabled = true;
                    panel.SetActive(true);
                    entregar1.gameObject.SetActive(false);
                    entregar2.gameObject.SetActive(false);
                    entregar3.gameObject.SetActive(false);
                }
                break;


            case 2:
                cerrar();
                break;


            case 3:
                if (!E2)
                {
                    panel2.SetActive(true);
                    entregar2.gameObject.SetActive(true);
                    entregar3.gameObject.SetActive(false);
                    entregar1.gameObject.SetActive(false);
                }
                if (E2)
                {
                    panel2.SetActive(true);
                    entregar2.gameObject.SetActive(false);
                    entregar3.gameObject.SetActive(false);
                    entregar1.gameObject.SetActive(false);
                }
                
                break;


            case 4:
                if (!E3)
                {
                    panel3.SetActive(true);
                    entregar3.gameObject.SetActive(true);
                    entregar2.gameObject.SetActive(false);
                    entregar1.gameObject.SetActive(false);
                }
                if (E3)
                {
                    panel3.SetActive(true);
                    entregar3.gameObject.SetActive(false);
                    entregar2.gameObject.SetActive(false);
                    entregar1.gameObject.SetActive(false);
                }
               
                break;
        }
    }

    public void abrir()
    {
        can.enabled = true;
        Time.timeScale = 0;
        Vercarta1.gameObject.SetActive(false);
        Vercarta2.gameObject.SetActive(false);
        Vercarta3.gameObject.SetActive(false);
        entregar1.gameObject.SetActive(false);
        entregar2.gameObject.SetActive(false);
        entregar3.gameObject.SetActive(false);
        minijuego.gameObject.SetActive(false);
    }

    public void cerrar()
    {
        can.enabled = false;
        Time.timeScale = 1;
    }

    private void Entrega1()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData HuevosItem = inventory.inventario.Find(item => item.nombre == "Huevo");
        InventoryItemData ZanItem = inventory.inventario.Find(item => item.nombre == "Zanahoria");
        InventoryItemData TomaItem = inventory.inventario.Find(item => item.nombre == "Tomate");

        if(HuevosItem != null && HuevosItem.count >=30 && ZanItem != null && ZanItem.count >= 6 && TomaItem != null && TomaItem.count >= 6)
        {
            HuevosItem.count -= 30;
            ZanItem.count -= 6;
            TomaItem.count -= 6;
            E1 = true;
            V1 = true;
        }
        else
        {
            Debug.Log("no");
        }


    }

    private void Entrega2()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData HuevosItem = inventory.inventario.Find(item => item.nombre == "Huevo");
        InventoryItemData CarneItem = inventory.inventario.Find(item => item.nombre == "Carne");
        InventoryItemData PatItem = inventory.inventario.Find(item => item.nombre == "Patata");
        InventoryItemData PiedraItem = inventory.inventario.Find(item => item.nombre == "Roca");
        InventoryItemData ManzanaItem = inventory.inventario.Find(item => item.nombre == "Manzana");

        if(HuevosItem != null && HuevosItem.count >= 55 && CarneItem != null && CarneItem.count >= 40 &&  PatItem != null &&PatItem.count >=8 && PiedraItem != null && PiedraItem.count >=3  && ManzanaItem != null && ManzanaItem.count >= 10)
        {
            HuevosItem.count -= 55;
            CarneItem.count -= 40;
            PatItem.count -= 8;
            ManzanaItem.count -= 10;
            PiedraItem.count -= 3;
            E2 = true;
            V2 = true;
        }
        else
        {
            Debug.Log("no");
        }
    }

    private void Entrega3()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData HuevosItem = inventory.inventario.Find(item => item.nombre == "Huevo");
        InventoryItemData CarneItem = inventory.inventario.Find(item => item.nombre == "Carne");
        InventoryItemData LecheItem = inventory.inventario.Find(item => item.nombre == "Leche");
        InventoryItemData MaderaItem = inventory.inventario.Find(item => item.nombre == "Madera");
        InventoryItemData PimientosItem = inventory.inventario.Find(item => item.nombre == "Pimiento");
        InventoryItemData NaranjasItem = inventory.inventario.Find(item => item.nombre == "Naranja");

        if(HuevosItem != null && HuevosItem.count >= 60 && CarneItem != null && CarneItem.count >= 60 && LecheItem != null && LecheItem.count >= 50 && MaderaItem != null && MaderaItem.count >= 8 && PimientosItem != null && PimientosItem.count >=10 && NaranjasItem != null && NaranjasItem.count >= 10)
        {
            HuevosItem.count -= 60;
            CarneItem.count -= 60;
            LecheItem.count -= 50;
            MaderaItem.count -= 10;
            PimientosItem.count -= 10;
            NaranjasItem.count -= 10;
            E3 = true;
        }
        else
        {
            Debug.Log("no");
        }

    }

    private void Minijuego()
    {
        
        m.gameObject.SetActive(true);
        miniJuego.SetActive(true);
    }
}
