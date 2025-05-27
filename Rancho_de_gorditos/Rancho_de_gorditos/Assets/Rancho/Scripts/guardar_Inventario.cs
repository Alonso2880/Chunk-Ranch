using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class guardar_Inventario : MonoBehaviour
{
    public static guardar_Inventario Instance { get; private set; }

    GameObject player, objeto, colisionado, huevoG, CarneC, LanaL, LecheL;
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();
    [HideInInspector] public bool recogidaH = false;
    public Animator animator;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            // Nos suscribimos al evento de escena cargada
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()

    {
        player = this.gameObject;
        objeto = GameObject.FindGameObjectWithTag("objeto");
        huevoG = GameObject.Find("Huevo");
        CarneC = GameObject.Find("Carne");
        LecheL = GameObject.Find("Leche");
        LanaL = GameObject.Find("Lana");
        FindSceneReferences();

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Cada vez que cambie de escena, re-asignamos referencias
        FindSceneReferences();
    }

    void FindSceneReferences()
    {
        objeto = GameObject.FindGameObjectWithTag("objeto");
        huevoG = GameObject.Find("Huevo");
        CarneC = GameObject.Find("Carne");
        LecheL = GameObject.Find("Leche");
        LanaL = GameObject.Find("Lana");
        colisionado = null;
    }


    void Update()
    {

        //Agregar item al inventario
        if (colisionado != null && Input.GetKeyDown(KeyCode.E))
        {

            if (colisionado.tag == "Recogida_Huevos")
            {
                AgregarHuevo();
                Debug.Log("Hola");
                colisionado = null;
                StartCoroutine(DisparaYCancelaCoger());
            }
            else
            {
                if (colisionado.tag == "Recogida_Carne")
                {
                    AgregarCarne();
                    Debug.Log("Hola");
                    colisionado = null;
                    StartCoroutine(DisparaYCancelaCoger());
                }
                else
                {
                    if (colisionado.tag == "Recogida_Leche")
                    {
                        AgregarLeche();
                        Debug.Log("Hola");
                        colisionado = null;
                        StartCoroutine(DisparaYCancelaCoger());
                    }
                    else
                    {
                        if (colisionado.tag == "Recogida_Lana")
                        {
                            AgregarLana();
                            Debug.Log("Hola");
                            colisionado = null;
                            StartCoroutine(DisparaYCancelaCoger());
                        }
                        else
                        {
                            ItemCount itemData = colisionado.GetComponent<ItemCount>();
                            if (itemData != null)
                            {

                                AgregarItem(itemData.nombre, itemData.prefab);
                                Destroy(colisionado);
                                colisionado = null;
                                StartCoroutine(DisparaYCancelaCoger());

                            }
                        }
                    }
                }
            }

        }

    }

    private IEnumerator DisparaYCancelaCoger()
    {
        animator.SetBool("Coger", true);
        // espera **un frame**:
        yield return null;
        animator.SetBool("Coger", false);
    }

    //Agregar item al inventario
    public void AgregarItem(string nombre, GameObject prefab)
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == nombre);
        InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
        //huevo h = huevoG.GetComponent<huevo>();

        if (itemExiste != null)
        {
            itemExiste.count++;
            inventoryUI.UpdateUI();
        }
        else
        {

            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = nombre;
            nuevoItem.count = 1;
            nuevoItem.prefab = prefab;
            inventario.Add(nuevoItem);
        }
        /* InventoryUI inventoryUI = Object.FindAnyObjectByType<InventoryUI>();
         if (inventoryUI != null && inventoryUI.inventoryPanel.activeSelf)
         {
             inventoryUI.UpdateUI();
         }*/
    }

    private void AgregarHuevo()
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == "Huevo");
        huevo h = huevoG.GetComponent<huevo>();
        if (itemExiste != null)
        {

            itemExiste.count += h.HuevoTotal;
            h.Reset();
        }
        else
        {
            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = "Huevo";
            nuevoItem.count = h.HuevoTotal;
            inventario.Add(nuevoItem);
            h.Reset();
        }

    }

    private void AgregarCarne()
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == "Carne");
        Carne c = CarneC.GetComponent<Carne>();
        if (itemExiste != null)
        {

            itemExiste.count += c.CarneTotal;
            c.Reset();
        }
        else
        {
            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = "Carne";
            nuevoItem.count = c.CarneTotal;
            inventario.Add(nuevoItem);
            c.Reset();
        }

    }

    private void AgregarLana()
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == "Lana");
        Lana l = LanaL.GetComponent<Lana>();
        if (itemExiste != null)
        {

            itemExiste.count += l.LanaTotal;
            l.Reset();
        }
        else
        {
            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = "Lana";
            nuevoItem.count = l.LanaTotal;
            inventario.Add(nuevoItem);
            l.Reset();
        }

    }

    private void AgregarLeche()
    {
        InventoryItemData itemExiste = inventario.Find(item => item.nombre == "Leche");
        Leche l = LecheL.GetComponent<Leche>();
        if (itemExiste != null)
        {

            itemExiste.count += l.LecheTotal;
            l.Reset();
        }
        else
        {
            InventoryItemData nuevoItem = new InventoryItemData();
            nuevoItem.nombre = "Leche";
            nuevoItem.count = l.LecheTotal;
            inventario.Add(nuevoItem);
            l.Reset();
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("objeto"))
        {
            colisionado = collision.gameObject;
        }
        if (collision.gameObject.CompareTag("Recogida_Huevos"))
        {
            colisionado = collision.gameObject;
            recogidaH = true;

        }

        if (collision.gameObject.CompareTag("Recogida_Lana"))
        {
            colisionado = collision.gameObject;
            recogidaH = true;

        }

        if (collision.gameObject.CompareTag("Recogida_Leche"))
        {
            colisionado = collision.gameObject;
            recogidaH = true;

        }

        if (collision.gameObject.CompareTag("Recogida_Carne"))
        {
            colisionado = collision.gameObject;
            recogidaH = true;

        }
    }
}
