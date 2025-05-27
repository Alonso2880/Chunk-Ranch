using System.Collections.Generic;
using UnityEngine;

public class Hechizo : MonoBehaviour
{
    private GameObject hechizos, Casa;
    [HideInInspector] public GameObject col;
    public GameObject prefabSemilla;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    [HideInInspector] public bool enZona = false;
    private bool toD = false, zaD = false, maD = false, patD = false, piD = false, naD = false;
    private int d;
    void Start()
    {
        hechizos = GameObject.Find("Hechizos");
        Casa = GameObject.Find("CasaBrujita");
        d = 0;
    }


    void Update()
    {
        guardar_Inventario inventarioScript = GameObject.FindAnyObjectByType<guardar_Inventario>();
        Hechizos h = hechizos.GetComponent<Hechizos>();
        casa c = Casa.GetComponent<casa>();
        if (c.dia != d)
        {
            d = c.dia;
            // resetea los flags de “ya dado hoy”:
            toD = zaD = maD = patD = piD = naD = false;
            // ¡y limpia aquí cualquier hechizo “pendiente”!
            h.tomate = false;
            h.zanahoria = false;
            h.manzana = false;
            h.patatas = false;
            h.pimientos = false;
            h.naranjas = false;
        }

        if (enZona && Input.GetKeyDown(KeyCode.H))
        {
            h.canvas.enabled = true;
            Time.timeScale = 0;

        }

        if (h.tomate && !toD)
        {
            Debug.Log("Has conseguido un tomate");
            inventarioScript.AgregarItem("Semilla_Tomate", prefabSemilla);
            h.tomate = false;
            toD = true;
            Time.timeScale = 1;
        }

        if (h.zanahoria && !zaD)
        {
            Debug.Log("Has conseguido una zanahoria");
            inventarioScript.AgregarItem("Semilla_Zanahoria", prefabSemilla);
            h.zanahoria = false;
            zaD = true;
            Time.timeScale = 1;
        }

        if (h.manzana && !maD)
        {
            Debug.Log("Has conseguido una manzana");
            inventarioScript.AgregarItem("Manzana", prefabSemilla);
            h.manzana = false;
            maD = true;
            Time.timeScale = 1;
        }

        if (h.patatas && !patD)
        {
            Debug.Log("Has conseguido una patata");
            inventarioScript.AgregarItem("Semilla_Patata", prefabSemilla);
            h.patatas = false;
            patD = true;
            Time.timeScale = 1;
        }

        if (h.pimientos && !piD)
        {
            Debug.Log("Has conseguido unos pimientos");
            inventarioScript.AgregarItem("Semilla_Pimiento", prefabSemilla);
            h.pimientos = false;
            piD = true;
            Time.timeScale = 1;
        }

        if (h.naranjas && !naD)
        {
            Debug.Log("Has conseguido unas naranjas");
            inventarioScript.AgregarItem("Naranja", prefabSemilla);
            h.naranjas = false;
            naD = true;
            Time.timeScale = 1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlantaSemilla1"))
        {
            enZona = true;
            col = collision.gameObject;
            

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlantaSemilla1"))
        {
            enZona = false;
            
        }

    }
}

