using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    [HideInInspector] public List<InventoryItemData> inventario = new List<InventoryItemData>();

    public Transform itemsParent;
    public GameObject inventoryPanel;
    public GameObject itemUIPrefab, buzón;
   [HideInInspector] public Canvas c;
    public Button salir;
    private bool adios=false;

    private GameObject player;

    public List<Image> Iconos;
    public List<Button> IconoButtons;
    public List<bool> IconosB;

    private GameObject Ajs;
    public Button Ajustes, Cartas;


    //Sprites
    public Sprite Spritehuevo;
    public Sprite Spritecarne;
    public Sprite SpriteLana;
    public Sprite SpriteLeche;
    public Sprite SpriteMadera;
    public Sprite SpritePiedra;
    public Sprite SpriteManzana;
    public Sprite SpriteNaranja;
    public Sprite SpritePatata;
    public Sprite SpriteZanahoria;
    public Sprite SpriteTomate;
    public Sprite SpritePimiento;
    public Sprite SpriteSemillaPatata;
    public Sprite SpriteSemillaPimiento;
    public Sprite SpriteSemillaTomate;
    public Sprite SpriteSemillaZanahoria;
    public Sprite TestSprite;

    //Polaroids
    public Image PolariodHuevo;
    public Image PolariodCarne;
    public Image PolariodLana;
    public Image PolariodLeche;
    public Image PolariodMadera;
    public Image PolariodPiedra;
    public Image PolariodManzana;
    public Image PolariodNaranja;
    public Image PolariodPatata;
    public Image PolariodZanahoria;
    public Image PolariodTomate;
    public Image PolariodPimiento;
    public Image PolariodSemillaPatata;
    public Image PolariodSemillaPimiento;
    public Image PolariodSemillaTomate;
    public Image PolariodSemillaZanahoria;

    //Textos
    public Image TextoHuevo;
    public Image TextoCarne;
    public Image TextoLana;
    public Image TextoLeche;
    public Image TextoMadera;
    public Image TextoPiedra;
    public Image TextoManzana;
    public Image TextoNaranja;
    public Image TextoPatata;
    public Image TextoZanahoria;
    public Image TextoTomate;
    public Image TextoPimiento;
    public Image TextoSemillaPatata;
    public Image TextoSemillaPimiento;
    public Image TextoSemillaTomate;
    public Image TextoSemillaZanahoria;

    void Start()
    {
        
        c = inventoryPanel.GetComponent<Canvas>();
        c.enabled = false;
        salir.onClick.AddListener(() => ads());
        Ajustes.onClick.AddListener(() => ajus());
        Cartas.onClick.AddListener(() => buz());
        player = GameObject.Find("Player");
        Ajs = GameObject.Find("MenuPausa");

    }

    private void ajus()
    {
        MenuPausaUI a = Ajs.GetComponent<MenuPausaUI>();
        c.enabled = false;
        a.inicio();
    }

    private void buz()
    {
        BuzónUI b = buzón.GetComponent<BuzónUI>();
        c.enabled = false;
        b.abrir();
    }
    private void ads()
    {
        c.enabled = false;
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            
                c.enabled = !c.enabled;
                Time.timeScale = c.enabled ? 0 : 1;
                if (c.enabled)
                {
                    UpdateUI();

                DesaparecerIconos();

                MostrarIconoHuevo();
                MostrarIconoZanahoria();
                MostrarIconoCarne();
                MostrarIconoLana();
                MostrarIconoLeche();
                MostrarIconoMadera();
                MostrarIconoRoca();
                MostrarIconoManzana();
                MostrarIconoNaranja();
                MostrarIconoPatata();
                MostrarIconoPimiento();
                MostrarIconoSemillaPatata();
                MostrarIconoSemillaPimiento();
                MostrarIconoSemillaTomate();
                MostrarIconoTomate();
                MostrarIconoZanahoria1();
            }
                adios = true;
        }

        
    }


    private void MostrarIconoHuevo()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData huevoItem = inventory.inventario.Find(item => item.nombre == "Huevo");

        if (huevoItem != null && huevoItem.count >= 1)
        {
            for(int i =0; i<Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = Spritehuevo;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoHuevo);
                    IconosB[i] = true;
                    break;
                }
                
            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == Spritehuevo)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoHuevo);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoZanahoria()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData ZanahoriaItem = inventory.inventario.Find(item => item.nombre == "Semilla_Zanahoria");

        if (ZanahoriaItem != null && ZanahoriaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteSemillaZanahoria;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoSemillaZanahoria);
                    IconosB[i] = true;
                    break;
                }
                
            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteSemillaZanahoria)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoSemillaZanahoria);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoCarne()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData CarneItem = inventory.inventario.Find(item => item.nombre == "Carne");

        if (CarneItem != null && CarneItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = Spritecarne;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoCarne);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == Spritecarne)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoCarne);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoLana()
    {
        
        var inventory = guardar_Inventario.Instance;
        InventoryItemData LanaItem = inventory.inventario.Find(item => item.nombre == "Lana");

        if (LanaItem != null && LanaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteLana;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoLana);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteLana)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoLana);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoLeche()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData LecheItem = inventory.inventario.Find(item => item.nombre == "Leche");

        if (LecheItem != null && LecheItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteLeche;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoLeche);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteLeche)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoLeche);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoMadera()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData MaderaItem = inventory.inventario.Find(item => item.nombre == "Madera");

        if (MaderaItem != null && MaderaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteMadera;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoMadera);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteMadera)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoMadera);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoRoca()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData RocaItem = inventory.inventario.Find(item => item.nombre == "Roca");

        if (RocaItem != null && RocaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpritePiedra;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoRoca);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpritePiedra)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoRoca);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoManzana()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData ManzanaItem = inventory.inventario.Find(item => item.nombre == "Manzana");

        if (ManzanaItem != null && ManzanaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteManzana;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoManzana);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteManzana)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoManzana);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoNaranja()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData NaranjaItem = inventory.inventario.Find(item => item.nombre == "Naranja");

        if (NaranjaItem != null && NaranjaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteNaranja;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoNaranja);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteLana)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoLana);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoPatata()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData PatataItem = inventory.inventario.Find(item => item.nombre == "Patata");

        if (PatataItem != null && PatataItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpritePatata;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoPatata);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpritePatata)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoPatata);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoPimiento()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData PimientoItem = inventory.inventario.Find(item => item.nombre == "Pimiento");

        if (PimientoItem != null && PimientoItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpritePimiento;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoPimiento);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpritePimiento)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoPimiento);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoSemillaPatata()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData SemillaPatataItem = inventory.inventario.Find(item => item.nombre == "Semilla_Patata");

        if (SemillaPatataItem != null && SemillaPatataItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteSemillaPatata;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoSemillaPatata);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteSemillaPatata)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoSemillaPatata);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoSemillaPimiento()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData SemillaPimientoItem = inventory.inventario.Find(item => item.nombre == "Semilla_Pimiento");

        if (SemillaPimientoItem != null && SemillaPimientoItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteSemillaPimiento;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoSemillaPimiento);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteSemillaPimiento)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoSemillaPimiento);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoSemillaTomate()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData SemillaTomateItem = inventory.inventario.Find(item => item.nombre == "Semilla_Tomate");

        if (SemillaTomateItem != null && SemillaTomateItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteSemillaTomate;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoSemillaTomate);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteSemillaTomate)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoSemillaTomate);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoTomate()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData TomateItem = inventory.inventario.Find(item => item.nombre == "Tomate");

        if (TomateItem != null && TomateItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteTomate;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoTomate);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteTomate)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoTomate);
                    IconosB[i] = false;
                }
            }
        }
    }

    private void MostrarIconoZanahoria1()
    {
        var inventory = guardar_Inventario.Instance;
        InventoryItemData ZanahoriaItem = inventory.inventario.Find(item => item.nombre == "Zanahoria");

        if (ZanahoriaItem != null && ZanahoriaItem.count >= 1)
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (!IconosB[i])
                {
                    Iconos[i].sprite = SpriteZanahoria;
                    Iconos[i].enabled = true;
                    IconoButtons[i].onClick.AddListener(InfoZanahoria);
                    IconosB[i] = true;
                    break;
                }

            }


        }
        else
        {
            for (int i = 0; i < Iconos.Count; i++)
            {
                if (IconosB[i] && Iconos[i].sprite == SpriteZanahoria)
                {
                    Iconos[i].sprite = null;
                    Iconos[i].enabled = false;
                    IconoButtons[i].onClick.RemoveListener(InfoZanahoria);
                    IconosB[i] = false;
                }
            }
        }
    }



    //Funciones de información
    private void InfoHuevo()
    {
        DesactivarInfo();
        PolariodHuevo.enabled = true;
        TextoHuevo.enabled = true;
    }

    private void InfoSemillaZanahoria()
    {
        DesactivarInfo();
        PolariodSemillaZanahoria.enabled = true;
        TextoSemillaZanahoria.enabled=true;
    }

    private void InfoCarne()
    {
        DesactivarInfo();
        PolariodCarne.enabled = true;
        TextoCarne.enabled = true;
    }

    private void InfoLana()
    {
        DesactivarInfo();
        PolariodLana.enabled = true;
        TextoLana.enabled = true;
    }

    private void InfoLeche()
    {
        DesactivarInfo();
        PolariodLeche.enabled = true;
        TextoLeche.enabled = true;
    }

    private void InfoMadera()
    {
        DesactivarInfo();
        PolariodMadera.enabled = true;
        TextoMadera.enabled = true;
    }

    private void InfoRoca()
    {
        DesactivarInfo();
        PolariodPiedra.enabled = true;
        TextoPiedra.enabled = true;
    }

    private void InfoManzana()
    {
        DesactivarInfo();
        PolariodManzana.enabled = true;
        TextoManzana.enabled = true;
    }

    private void InfoNaranja()
    {
        DesactivarInfo();
        PolariodNaranja.enabled = true;
        TextoNaranja.enabled = true;
    }

    private void InfoPatata()
    {
        DesactivarInfo();
        PolariodPatata.enabled = true;
        TextoPatata.enabled = true;
    }

    private void InfoPimiento()
    {
        DesactivarInfo();
        PolariodPimiento.enabled = true;
        TextoPimiento.enabled = true;
    }

    private void InfoTomate()
    {
        DesactivarInfo();
        PolariodTomate.enabled = true;
        TextoTomate.enabled = true;
    }

    private void InfoZanahoria()
    {
        DesactivarInfo();
        PolariodZanahoria.enabled = true;
        TextoZanahoria.enabled = true;
    }

    private void InfoSemillaPatata()
    {
        DesactivarInfo();
        PolariodSemillaPatata.enabled = true;
        TextoSemillaPatata.enabled = true;
    }

    private void InfoSemillaPimiento()
    {
        DesactivarInfo();
        PolariodSemillaPimiento.enabled = true;
        TextoSemillaPimiento.enabled = true;
    }

    private void InfoSemillaTomate()
    {
        DesactivarInfo();
        PolariodSemillaTomate.enabled = true;
        TextoSemillaTomate.enabled = true;
    }
    public void UpdateUI()
    {
        // Destruye todos los elementos viejos
        foreach (Transform child in itemsParent)
            Destroy(child.gameObject);

        // Obtén siempre la misma instancia
        var inventory = guardar_Inventario.Instance;
        if (inventory == null) return;

        // Recorre la lista
        foreach (var item in inventory.inventario)
        {
            var go = Instantiate(itemUIPrefab, itemsParent);
            go.GetComponent<TMP_Text>().text = $"{item.nombre} x{item.count}";
        }
    }

    //Este código evita que al darle varias vecea a la I se duplicaran los sprites
    private void DesaparecerIconos()
    {
        for (int i = 0; i < Iconos.Count; i++)
        {
            if (IconosB[i])
            {
                // Elimina cualquier listener que pudiera quedarse para evitar callbacks colgando
                IconoButtons[i].onClick.RemoveAllListeners();

                // Limpia el sprite y la visibilidad
                Iconos[i].sprite = null;
                Iconos[i].enabled = false;

                // Marca el slot como vacío
                IconosB[i] = false;
            }
        }
    }

    private void DesactivarInfo()
    {
        PolariodHuevo.enabled = false;
        PolariodCarne.enabled = false;
        PolariodLana.enabled = false;
        PolariodLeche.enabled = false;
        PolariodMadera.enabled = false;
        PolariodPiedra.enabled = false;
        PolariodManzana.enabled = false;
        PolariodNaranja.enabled = false;
        PolariodPatata.enabled = false;
        PolariodZanahoria.enabled = false;
        PolariodTomate.enabled = false;
        PolariodPimiento.enabled = false;
        PolariodSemillaPatata.enabled = false;
        PolariodSemillaPimiento.enabled = false;
        PolariodSemillaTomate.enabled = false;
        PolariodSemillaZanahoria.enabled = false;

        TextoHuevo.enabled = false;
        TextoCarne.enabled = false;
        TextoLana.enabled = false;
        TextoLeche.enabled = false;
        TextoMadera.enabled = false;
        TextoPiedra.enabled = false;
        TextoManzana.enabled = false;
        TextoNaranja.enabled = false;
        TextoPatata.enabled = false;
        TextoZanahoria.enabled = false;
        TextoTomate.enabled = false;
        TextoPimiento.enabled = false;
        TextoSemillaPatata.enabled = false;
        TextoSemillaPimiento.enabled = false;
        TextoSemillaTomate.enabled = false;
        TextoSemillaZanahoria.enabled = false;
    }

}
