using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu_Parcelas2 : MonoBehaviour
{
    private GameObject gallina, cerdo, vaca, oveja;
    public GameObject terreno, buzon;
    private Canvas canvasP;
    public Button Comprar_Gallinas;
    public Button Comprar_Vacas;
    public Button Comprar_Cerdos;
    public Button Comprar_Ovejas;
    public Button Mejorar;
    public Button Ampliar;
    public Button Salir;
    [HideInInspector] public bool comprado=false;
    [HideInInspector] public GameObject contmonedas;
    private bool galli = false;

    public GameObject baseParcelas;
    public bool GaCom = false, CeCOm = false, VacCom = false, OveCom = false, AmR = false;

    public AudioClip Si, No;
    public bool Mej = false, ampl = false;
    void Start()
    {
        Comprar_Gallinas.onClick.AddListener(() => ComprarP(1));
        Comprar_Vacas.onClick.AddListener(() => ComprarP(2));
        Comprar_Cerdos.onClick.AddListener(() => ComprarP(3));
        Comprar_Ovejas.onClick.AddListener(() => ComprarP(4));
        Mejorar.onClick.AddListener(() => Mejoras(1));
        Ampliar.onClick.AddListener(()=> Mejoras(2));
        Salir.onClick.AddListener(() => ComprarP(5));
        Salir.onClick.AddListener(() => Mejoras(3));

        canvasP = GetComponent<Canvas>();
        canvasP.enabled = false;

        baseParcelas = GameObject.Find("Base de parcelas2");
        gallina = GameObject.Find("Pollo");
        cerdo = GameObject.Find("Cerdo");
        vaca = GameObject.Find("Vaca");
        oveja = GameObject.Find("Oveja");
        contmonedas = GameObject.Find("Canvas");
        //buzon = GameObject.Find("Men�Buz�n");
    }

    private void Update()
    {
        if (Mej)
        {
            Mejorar.gameObject.SetActive(false);
        }

        if (ampl)
        {
            Ampliar.gameObject.SetActive(false);
        }
    }

    public void ComprarP(int n)
    {
        A�adir_Mejorar_Parcela2 a = baseParcelas.GetComponent<A�adir_Mejorar_Parcela2>();
        Contador_Moneas cont = contmonedas.GetComponent<Contador_Moneas>();
        if (comprado == false)
        {
            switch (n)
            {
                case 1:
                    if (cont.monedas >= 50)
                    {
                        a.GenerarParcelaGallina();
                        terreno.tag = "T_Gallinas";
                        galli = true;
                        CerrarMenu();
                        comprado = true;
                        GaCom = true;
                        cont.monedas -= 50;
                        GetComponent<AudioSource>().PlayOneShot(Si);
                        return;
                        
                    }
                    else
                    {
                        GetComponent<AudioSource>().PlayOneShot(No);
                    }
                    break;

                case 2:
                    if(cont.monedas >= 50)
                    {
                        a.GenerarParcelaVaca();
                        terreno.tag = "T_Vacas";
                        CerrarMenu();
                        comprado = true;
                        AmR = true;
                        VacCom = true;
                        cont.monedas -= 50;
                        GetComponent<AudioSource>().PlayOneShot(Si);
                        return;

                    }
                    else
                    {
                        GetComponent<AudioSource>().PlayOneShot(No);
                    }
                    break;

                case 3:
                    if(cont.monedas >= 50)
                    {
                        a.GenerarParcelaCerdo();
                        terreno.tag = "T_Cerdos";
                        CerrarMenu();
                        comprado = true;
                        AmR = true;
                        CeCOm = true;
                        cont.monedas -= 50;
                        GetComponent<AudioSource>().PlayOneShot(Si);
                        return;
                    }
                    else
                    {
                        GetComponent<AudioSource>().PlayOneShot(No);
                    }
                    break;

                case 4:
                    if(cont.monedas >= 50)
                    {
                        a.GenerarParcelaOveja();
                        terreno.tag = "T_Ovejas";
                        CerrarMenu();
                        comprado = true;
                        AmR = true;
                        OveCom = true;
                        cont.monedas -= 50;
                        GetComponent<AudioSource>().PlayOneShot(Si);
                        return;
                    }
                    else
                    {
                        GetComponent<AudioSource>().PlayOneShot(No);

                    }
                    break;
                case 5:
                    CerrarMenu();
                    break;
            }
        }
      
    }

    public void Mejoras(int n)
    {
        A�adir_Mejorar_Parcela2 a = baseParcelas.GetComponent<A�adir_Mejorar_Parcela2>();
        Gallina g = gallina.GetComponent<Gallina>();
        Cerdo c = cerdo.GetComponent<Cerdo>();
        Vaca v = vaca.GetComponent<Vaca>();
        Oveja o = oveja.GetComponent<Oveja>();
        Contador_Moneas cont = contmonedas.GetComponent<Contador_Moneas>();
        var inventory = guardar_Inventario.Instance;
        InventoryItemData MaderaItem = inventory.inventario.Find(item => item.nombre == "Madera");
        if (comprado)
        {
            switch (n)
            {
                case 1:
                    if (cont.monedas < 30)
                    {
                        Debug.Log("Te faltan monedas");
                        GetComponent<AudioSource>().PlayOneShot(No);
                    }
                    else
                    {
                        if (terreno.tag == "T_Gallinas" && GaCom)
                        {
                            Gallina.multHuevo = 2;
                            g.tiempoHuevo = 3;
                            GetComponent<AudioSource>().PlayOneShot(Si);
                            Mej = true;
                            cont.monedas -= 30;
                        }

                        if (terreno.tag == "T_Cerdos" && CeCOm)
                        {
                            Cerdo.multcarne = 2;
                            c.tiempoCarne = 4;
                            GetComponent<AudioSource>().PlayOneShot(Si);
                            Mej = true;
                            
                            cont.monedas -= 30;
                        }

                        if (terreno.tag == "T_Vacas" && VacCom)
                        {
                            Vaca.multLeche = 2;
                            v.tiempoLeche = 6;
                            GetComponent<AudioSource>().PlayOneShot(Si);
                            Mej = true;
                          
                            cont.monedas -= 30;
                        }

                        if (terreno.tag == "T_Ovejas" && OveCom)
                        {
                            Oveja.multLana = 2;
                            o.tiempoLana = 8;
                            GetComponent<AudioSource>().PlayOneShot(Si);
                            Mej = true;
                          
                            cont.monedas -= 30;
                        }


                    }

                    CerrarMenu();
                    break;
                case 2:
                    if (MaderaItem != null && MaderaItem.count >= 15 && galli && !AmR)
                    {
                        a.AmpliarParcela();
                        GetComponent<AudioSource>().PlayOneShot(Si);
                        ampl = true;
                        MaderaItem.count -= 15;
                    }
                    
                    if (MaderaItem != null && MaderaItem.count >= 15 && AmR)
                    {
                            a.AmpliarParcelaResto();
                            GetComponent<AudioSource>().PlayOneShot(Si);
                            ampl = true;
                            MaderaItem.count -= 15;
                    }
                    else
                    {
                            Debug.Log("Te faltan monedas");
                            GetComponent<AudioSource>().PlayOneShot(No);

                    }
                    

                    CerrarMenu();
                    break;
                case 3:
                    CerrarMenu();
                    break;
            }
        }

    }

    public void AbrirMenu()
    {
        canvasP.enabled = true;
        Time.timeScale = 0;
        Buz�nUI b = buzon.GetComponent<Buz�nUI>();
        if (comprado == false && !b.E1 && !b.E2 && !b.E3)
        {
            Comprar_Gallinas.gameObject.SetActive(true);
            Comprar_Vacas.gameObject.SetActive(false);
            Comprar_Cerdos.gameObject.SetActive(false);
            Comprar_Ovejas.gameObject.SetActive(false);
            Mejorar.gameObject.SetActive(false);
            Ampliar.gameObject.SetActive(false);

        }
        else
        {
            if (comprado == false && b.E1 && !b.E2 && !b.E3)
            {
                Comprar_Gallinas.gameObject.SetActive(true);
                Comprar_Vacas.gameObject.SetActive(false);
                Comprar_Cerdos.gameObject.SetActive(true);
                Comprar_Ovejas.gameObject.SetActive(false);
                Mejorar.gameObject.SetActive(false);
                Ampliar.gameObject.SetActive(false);

            }
            else
            {

                if (comprado == false && b.E2 && !b.E3)
                {
                    Comprar_Gallinas.gameObject.SetActive(true);
                    Comprar_Vacas.gameObject.SetActive(true);
                    Comprar_Cerdos.gameObject.SetActive(true);
                    Comprar_Ovejas.gameObject.SetActive(false);
                    Mejorar.gameObject.SetActive(false);
                    Ampliar.gameObject.SetActive(false);

                }
                else
                {
                    if (comprado == false && b.E3)
                    {
                        Comprar_Gallinas.gameObject.SetActive(true);
                        Comprar_Vacas.gameObject.SetActive(true);
                        Comprar_Cerdos.gameObject.SetActive(true);
                        Comprar_Ovejas.gameObject.SetActive(true);
                        Mejorar.gameObject.SetActive(false);
                        Ampliar.gameObject.SetActive(false);
                    }
                    else
                    {
                        Comprar_Gallinas.gameObject.SetActive(false);
                        Comprar_Vacas.gameObject.SetActive(false);
                        Comprar_Cerdos.gameObject.SetActive(false);
                        Comprar_Ovejas.gameObject.SetActive(false);
                        Mejorar.gameObject.SetActive(true);
                        Ampliar.gameObject.SetActive(true);
                    }

                }
            }

        }
    }

    public void CerrarMenu()
    {
        canvasP.enabled = false;
        Time.timeScale = 1;
    }
    
}
