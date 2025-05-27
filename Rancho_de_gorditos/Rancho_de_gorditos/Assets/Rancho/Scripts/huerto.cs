using UnityEngine;

public class huerto : MonoBehaviour
{
    public GameObject semilla, brote, manzano, naranjo, patatas, pimientos, tomates, zanahorias;
    private GameObject huertoUI, jugador, Casa;
    [HideInInspector] public GameObject semilla1Prefab, semilla2Prefab;
    public Transform huecoPlantar, huecoPlantar2, huecoPlantar3, huecoPlantar4;
    private bool hueco1=false, hueco2=false, hueco3 = false, hueco4 = false;
    [HideInInspector] public int crec = 1, dia;

    private float YSemilla = 0.551f, YBrote = 0.925f, YZanahoria = 1.199f, YPatata = 0.862f, YTomate = 1.923f, YManzano = 3.172f, YNaranjo = 2.764f;
    private float XTomate = -1.924f, XNaranjo = -1.856f;

    [HideInInspector] public bool zanahoria = false, patata = false, tomate = false, pimiento = false;
    
    
    void Start()
    {
        huertoUI = GameObject.Find("HuertoUI");
        jugador = GameObject.FindGameObjectWithTag("Player");
        Casa = GameObject.Find("CasaBrujita");
        casa c = Casa.GetComponent<casa>();
        dia = c.dia;



    }

    
    void Update()
    {
        if (zanahoria)
        {
            crecimientoZanahoria();
        }
        
        if(patata)
        {
            crecimientoPatata();
        }

        if(tomate)
        {
            crecimientoTomates();
        }

        if (pimiento)
        {
            crecimientoPimientos();
        }
    }
    
    public void Semilla()
    {

        Vector3 nuevaPosHueco1 = huecoPlantar.localPosition;
        Vector3 nuevaPosHueco2 = huecoPlantar2.localPosition;

        if (hueco1 == false)
        {
            
                nuevaPosHueco1.y = YSemilla;
                huecoPlantar.localPosition = nuevaPosHueco1;
                semilla1Prefab = Instantiate(semilla, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                hueco1 = true;
                
                
            
            
        }else 
        if (hueco1 && !hueco2)
        {
            
                nuevaPosHueco2.y = YSemilla;
                huecoPlantar.transform.position= nuevaPosHueco2;
                Debug.Log("Segunda semi plant");
                semilla2Prefab = Instantiate(semilla, huecoPlantar2.position, huecoPlantar2.rotation);
                semilla2Prefab.transform.SetParent(huecoPlantar2);
                hueco2 = true;
                
               
            
            
        }
        
    }

    public void crecimientoZanahoria()
    {
        Vector3 nuevaPosHueco1 = huecoPlantar.localPosition;
        Vector3 nuevaPosHueco2 = huecoPlantar2.localPosition;

        casa c = Casa.GetComponent<casa>();
        if (hueco1 && crec ==1)
        {
            if(dia != c.dia)
            {
                Destroy(semilla1Prefab);
                nuevaPosHueco1.y = YBrote;
                huecoPlantar.localPosition = nuevaPosHueco1;
                semilla1Prefab = Instantiate(brote, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }

        if(hueco1 && crec == 2)
        {
            if (dia != c.dia)
            {
                nuevaPosHueco1.y = YZanahoria;
                huecoPlantar.localPosition = nuevaPosHueco1;
                Destroy(semilla1Prefab);
                semilla1Prefab = Instantiate(zanahorias, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }
    }

    public void crecimientoPatata()
    {
        Vector3 nuevaPosHueco1 = huecoPlantar.localPosition;
        Vector3 nuevaPosHueco2 = huecoPlantar2.localPosition;

        casa c = Casa.GetComponent<casa>();
        if (hueco1 && crec == 1)
        {
            if (dia != c.dia)
            {
                Destroy(semilla1Prefab);
                nuevaPosHueco1.y = YBrote;
                huecoPlantar.localPosition = nuevaPosHueco1;
                semilla1Prefab = Instantiate(brote, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }

        if (hueco1 && crec == 2)
        {
            if (dia != c.dia)
            {
                nuevaPosHueco1.y = YPatata;
                huecoPlantar.localPosition = nuevaPosHueco1;
                Destroy(semilla1Prefab);
                semilla1Prefab = Instantiate(patatas, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }
    }

    public void crecimientoTomates()
    {
        Vector3 nuevaPosHueco1 = huecoPlantar.localPosition;
        Vector3 nuevaPosHueco2 = huecoPlantar2.localPosition;

        casa c = Casa.GetComponent<casa>();
        if (hueco1 && crec == 1)
        {
            if (dia != c.dia)
            {
                Destroy(semilla1Prefab);
                nuevaPosHueco1.y = YBrote;
                huecoPlantar.localPosition = nuevaPosHueco1;
                semilla1Prefab = Instantiate(brote, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }

        if (hueco1 && crec == 2)
        {
            if (dia != c.dia)
            {
                nuevaPosHueco1.y = YTomate;
                huecoPlantar.localPosition = nuevaPosHueco1;
                Destroy(semilla1Prefab);
                semilla1Prefab = Instantiate(tomates, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }
    }

    private void crecimientoPimientos()
    {
        Vector3 nuevaPosHueco1 = huecoPlantar.localPosition;
        Vector3 nuevaPosHueco2 = huecoPlantar2.localPosition;

        casa c = Casa.GetComponent<casa>();
        if (hueco1 && crec == 1)
        {
            if (dia != c.dia)
            {
                Destroy(semilla1Prefab);
                nuevaPosHueco1.y = YBrote;
                huecoPlantar.localPosition = nuevaPosHueco1;
                semilla1Prefab = Instantiate(brote, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }

        if (hueco1 && crec == 2)
        {
            if (dia != c.dia)
            {
                nuevaPosHueco1.y = YTomate;
                huecoPlantar.localPosition = nuevaPosHueco1;
                Destroy(semilla1Prefab);
                semilla1Prefab = Instantiate(pimientos, huecoPlantar.position, huecoPlantar.rotation);
                semilla1Prefab.transform.SetParent(huecoPlantar);
                dia = c.dia;
                crec++;
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        HuertoUI h = huertoUI.GetComponent<HuertoUI>();
        if (collision.gameObject.CompareTag("Player"))
        {
           
        }
    }
}
