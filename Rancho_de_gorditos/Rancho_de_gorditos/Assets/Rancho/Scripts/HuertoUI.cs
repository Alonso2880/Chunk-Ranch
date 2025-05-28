using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HuertoUI : MonoBehaviour
{
    public Button Zanahoria, Patata, Cerrar, ComprarHuerto, MejorarHuerto, Cosechar, Tomate, Pimiento, MejoraHuerto;
    private HuertoManager huertoManager;
    public Canvas canvas;
    public GameObject HuertoPrerfab, buzon;
    public Transform HuecoHuerto, HuecoHuerto2, HuecoHuerto3, HuecoHuerto4;
    private GameObject HuertoG, jugador;
    private bool compHu1 = false, compHu2 = false, compHu3 = false, compHu4 = false, mejHu1 = false, mejHu2 = false, mejHu3 = false, mejHu4 = false;
    [HideInInspector] public GameObject contmonedas;

    public AudioClip Si, No;
    public bool meU = false;
    void Start()
    {
        huertoManager = Object.FindFirstObjectByType<HuertoManager>();
        Zanahoria.onClick.AddListener(() => Plantar(1));
        Patata.onClick.AddListener(() => Plantar(2));
        Tomate.onClick.AddListener(() => Plantar(3));
        Pimiento.onClick.AddListener(() => Plantar(4));
        Cerrar.onClick.AddListener(() => CerrarUI());
        ComprarHuerto.onClick.AddListener(() => ComprarH());
        Cosechar.onClick.AddListener(() => cosechar());
        MejoraHuerto.onClick.AddListener(() => mejorar());
        canvas.enabled = false;
        jugador = GameObject.Find("Player");

        Zanahoria.gameObject.SetActive(false);
        Patata.gameObject.SetActive(false);
        Tomate.gameObject.SetActive(false);
        Pimiento.gameObject.SetActive(false);
        Cosechar.gameObject.SetActive(false);
        MejoraHuerto.gameObject.SetActive(false);
        contmonedas = GameObject.Find("Canvas");
    }

    private void Plantar(int tipo)
    {
        guardar_Inventario g = jugador.GetComponent<guardar_Inventario>();
        InventoryItemData itemZa = g.inventario.Find(item => item.nombre == "Semilla_Zanahoria");
        InventoryItemData itemPa = g.inventario.Find(item => item.nombre == "Semilla_Patata");
        InventoryItemData itemTo = g.inventario.Find(item => item.nombre == "Semilla_Tomate");
        InventoryItemData itemPi = g.inventario.Find(item => item.nombre == "Semilla_Pimiento");

        if (tipo == 1)
        {
            if(itemZa != null && itemZa.count >= 1)
            {
                bool exito = huertoManager.PlantarSemilla(tipo);
                itemZa.count--;
                GetComponent<AudioSource>().PlayOneShot(Si);
                if (!exito)
                {
                    Debug.Log("No puedes plantar: huerto lleno.");
                    GetComponent<AudioSource>().PlayOneShot(No);
                }
            }
            else
            {
                Debug.Log("No tienes semillas de zanahoria");
                GetComponent<AudioSource>().PlayOneShot(No);
            }
        }

        if(tipo == 2)
        {
            if (itemPa != null && itemPa.count >= 1)
            {
                bool exito = huertoManager.PlantarSemilla(tipo);
                itemPa.count--;
                GetComponent<AudioSource>().PlayOneShot(Si);
                if (!exito)
                {
                    Debug.Log("No puedes plantar: huerto lleno.");
                    GetComponent<AudioSource>().PlayOneShot(No);
                }
            }
            else
            {
                Debug.Log("No tienes semillas de patata");
                GetComponent<AudioSource>().PlayOneShot(No);
            }
        }

        if(tipo == 3)
        {
            if (itemTo != null && itemTo.count >= 1)
            {
                bool exito = huertoManager.PlantarSemilla(tipo);
                itemTo.count--;
                GetComponent<AudioSource>().PlayOneShot(Si);
                if (!exito)
                {
                    Debug.Log("No puedes plantar: huerto lleno.");
                    GetComponent<AudioSource>().PlayOneShot(No);
                }
            }
            else
            {
                Debug.Log("No tienes semillas de tomate");
                GetComponent<AudioSource>().PlayOneShot(No);
            }
        }

        if(tipo == 4)
        {
            if (itemPi != null && itemPi.count >= 1)
            {
                bool exito = huertoManager.PlantarSemilla(tipo);
                itemPi.count--;
                GetComponent<AudioSource>().PlayOneShot(Si);
                if (!exito)
                {
                    Debug.Log("No puedes plantar: huerto lleno.");
                    GetComponent<AudioSource>().PlayOneShot(No);
                }
            }
            else
            {
                Debug.Log("No tienes semillas de pimiento");
                GetComponent<AudioSource>().PlayOneShot(No);
            }
        }
       
            
        CerrarUI();
    }

    private void ComprarH()
    {
        Contador_Moneas cont = contmonedas.GetComponent<Contador_Moneas>();
        if (!compHu1) 
        { 
            HuertoG = Instantiate(HuertoPrerfab, HuecoHuerto.position, HuecoHuerto.rotation);
            HuertoG.transform.SetParent(HuecoHuerto);
            compHu1 = true;
            GetComponent<AudioSource>().PlayOneShot(Si);
            CerrarUI();
            return;
        }

        if(compHu1 && mejHu1 && cont.monedas >=50)
        {
            HuertoG = Instantiate(HuertoPrerfab, HuecoHuerto2.position, HuecoHuerto2.rotation);
            HuertoG.transform.SetParent(HuecoHuerto2);
            compHu2 = true;
            cont.monedas -= 50;
            GetComponent<AudioSource>().PlayOneShot(Si);
            CerrarUI();
            return;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(No);
            
        }

        if(compHu2 && mejHu2 && cont.monedas >= 150)
        {
            HuertoG = Instantiate(HuertoPrerfab, HuecoHuerto3.position, HuecoHuerto3.rotation);
            HuertoG.transform.SetParent(HuecoHuerto3);
            cont.monedas -= 150;
            GetComponent<AudioSource>().PlayOneShot(Si);
            compHu3 = true;
            CerrarUI();
            return;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(No);
            
        }

        if(compHu3 && mejHu3 && cont.monedas >= 250)
        {
            HuertoG = Instantiate(HuertoPrerfab, HuecoHuerto4.position, HuecoHuerto4.rotation);
            HuertoG.transform.SetParent(HuecoHuerto4);
            cont.monedas -= 250;
            GetComponent<AudioSource>().PlayOneShot(Si);
            compHu4 = true;
            CerrarUI();
            return;
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(No);
            
        }
    }

    private void mejorar()
    {
        if (compHu1)
        {
            var inventory = guardar_Inventario.Instance;
            InventoryItemData RocaItem = inventory.inventario.Find(item => item.nombre == "Roca");
            if (RocaItem != null && RocaItem.count >= 10)
            {
                mejHu1 = true;
                RocaItem.count -= 10;
                GetComponent<AudioSource>().PlayOneShot(Si);
                CerrarUI();
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(No);
            }
            
        }

        if (compHu2)
        {
            var inventory = guardar_Inventario.Instance;
            InventoryItemData RocaItem = inventory.inventario.Find(item => item.nombre == "Roca");
            if(RocaItem != null && RocaItem.count >= 10)
            {
                mejHu2 = true;
                RocaItem.count -= 10;
                GetComponent<AudioSource>().PlayOneShot(Si);
                CerrarUI();
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(No);
            }

        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(No);
        }

        if (compHu3)
        {
            var inventory = guardar_Inventario.Instance;
            InventoryItemData RocaItem = inventory.inventario.Find(item => item.nombre == "Roca");
            if(RocaItem != null && RocaItem.count >= 10)
            {
                mejHu3 = true;
                RocaItem.count -= 10;
                GetComponent<AudioSource>().PlayOneShot(Si);
                CerrarUI();
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(No);
            }

        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(No);
        }

        if (compHu4)
        {
            var inventory = guardar_Inventario.Instance;
            InventoryItemData RocaItem = inventory.inventario.Find(item => item.nombre == "Roca");
            if(RocaItem != null && RocaItem.count >= 10)
            {
                mejHu4 = true;
                RocaItem.count -= 10;
                GetComponent<AudioSource>().PlayOneShot(Si);
                meU = true;
                CerrarUI();
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(No);
            }

        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(No);
        }
    }

    private void CerrarUI()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void AbrirUI()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
        BuzónUI b = buzon.GetComponent<BuzónUI>();

        if(compHu1 && !b.E1 && !b.E2)
        {
            Cosechar.gameObject.SetActive(true);
            MejoraHuerto.gameObject.SetActive(true);
            Zanahoria.gameObject.SetActive(true);
            Tomate.gameObject.SetActive(true);
            Patata.gameObject.SetActive(false);
            Pimiento.gameObject.SetActive(false);
        }

        if (compHu1 && b.E1 && !b.E2)
        {
            Cosechar.gameObject.SetActive(true);
            MejoraHuerto.gameObject.SetActive(true);
            Zanahoria.gameObject.SetActive(true);
            Tomate.gameObject.SetActive(true);
            Patata.gameObject.SetActive(true);
            Pimiento.gameObject.SetActive(false);
        }

        if (compHu1 && b.E1 && b.E2)
        {
            Cosechar.gameObject.SetActive(true);
            MejoraHuerto.gameObject.SetActive(true);
            Zanahoria.gameObject.SetActive(true);
            Tomate.gameObject.SetActive(true);
            Patata.gameObject.SetActive(true);
            Pimiento.gameObject.SetActive(true);
        }

        if (meU)
        {
            MejoraHuerto.gameObject.SetActive(false);
        }

    }

    private void cosechar()
    {
        var manager = Object.FindFirstObjectByType<HuertoManager>();
        List<Planta.Tipo> tipos = manager.CosecharTodas();
        var inventarioScript = jugador.GetComponent<guardar_Inventario>();
        foreach (var tipo in tipos)
        {
            // Asumiendo que cada tipo da 1 semilla
            switch (tipo)
            {
                case Planta.Tipo.Zanahoria:
                    inventarioScript.AgregarItem("Semilla_Zanahoria", null);
                    inventarioScript.AgregarItem("Zanahoria", null);

                    if (mejHu1)
                    {
                        inventarioScript.AgregarItem("Semilla_Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                    }

                    if (mejHu2)
                    {
                        inventarioScript.AgregarItem("Semilla_Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);

                    }

                    if (mejHu3)
                    {
                        inventarioScript.AgregarItem("Semilla_Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                    }

                    if (mejHu4)
                    {
                        inventarioScript.AgregarItem("Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                        inventarioScript.AgregarItem("Zanahoria", null);
                    }

                    break;
                case Planta.Tipo.Patata:
                    inventarioScript.AgregarItem("Semilla_Patata", null);
                    inventarioScript.AgregarItem("Patata", null);

                    if (mejHu1)
                    {
                        inventarioScript.AgregarItem("Semilla_Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                    }

                    if (mejHu2)
                    {
                        inventarioScript.AgregarItem("Semilla_Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                    }

                    if (mejHu3)
                    {
                        inventarioScript.AgregarItem("Semilla_Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                    }

                    if (mejHu4)
                    {
                        inventarioScript.AgregarItem("Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                        inventarioScript.AgregarItem("Patata", null);
                    }

                    break;

                case Planta.Tipo.Tomate:
                    inventarioScript.AgregarItem("Semilla_Tomate", null);
                    inventarioScript.AgregarItem("Tomate", null);

                    if (mejHu1)
                    {
                        inventarioScript.AgregarItem("Semilla_Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                    }

                    if (mejHu2)
                    {
                        inventarioScript.AgregarItem("Semilla_Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                    }

                    if (mejHu3)
                    {
                        inventarioScript.AgregarItem("Semilla_Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                    }

                    if (mejHu4)
                    {
                        inventarioScript.AgregarItem("Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                        inventarioScript.AgregarItem("Tomate", null);
                    }
                    break;

                case Planta.Tipo.Pimiento:
                    inventarioScript.AgregarItem("Semilla_Pimiento", null);
                    inventarioScript.AgregarItem("Pimiento", null);
                    if (mejHu1)
                    {
                        inventarioScript.AgregarItem("Semilla_Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                    }

                    if (mejHu2)
                    {
                        inventarioScript.AgregarItem("Semilla_Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                    }

                    if (mejHu3)
                    {
                        inventarioScript.AgregarItem("Semilla_Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                    }

                    if (mejHu4)
                    {
                        inventarioScript.AgregarItem("Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                        inventarioScript.AgregarItem("Pimiento", null);
                    }
                    break;
            }
            }
        }
    }

