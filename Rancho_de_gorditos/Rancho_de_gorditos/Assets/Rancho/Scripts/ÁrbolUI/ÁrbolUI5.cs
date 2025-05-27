using UnityEngine;
using UnityEngine.UI;
public class ÁrbolUI5 : MonoBehaviour
{
    public Button Comprar, Manzano, Naranjo, Mejorar, Salir, Cosechar;
    public Canvas c;
    public GameObject Manager, contMonedas, buzon;
    private GameObject player;
    [HideInInspector] public bool manzano = false, naranjo = false, huerto = false;
    [HideInInspector] public GameObject contmonedas;
    public bool mejorado = false;
    void Start()
    {
        c.enabled = false;
        Salir.onClick.AddListener(() => ads());
        Comprar.onClick.AddListener(() => ComprarHueco());
        Manzano.onClick.AddListener(() => Plantar(1));
        Naranjo.onClick.AddListener(() => Plantar(2));
        Mejorar.onClick.AddListener(() => Mejoras());
        Cosechar.onClick.AddListener(() => CosechaR());
        player = GameObject.Find("Player");
        contmonedas = GameObject.Find("Canvas");
    }

    private void FixedUpdate()
    {

    }

    public void hola()
    {
        BuzónUI b = buzon.GetComponent<BuzónUI>();
        c.enabled = true;
        Time.timeScale = 0;
        if (!b.E1 && !b.E2 && !huerto)
        {
            Manzano.gameObject.SetActive(false);
            Naranjo.gameObject.SetActive(false);
            Mejorar.gameObject.SetActive(false);
            Cosechar.gameObject.SetActive(false);
            Comprar.gameObject.SetActive(true);
        }

        if (huerto && !b.E1 && !b.E2)
        {
            Mejorar.gameObject.SetActive(true);
            Cosechar.gameObject.SetActive(true);
            Manzano.gameObject.SetActive(false);
            Naranjo.gameObject.SetActive(false);
            Comprar.gameObject.SetActive(false);
        }

        if (huerto && b.E1 && !b.E2)
        {
            Mejorar.gameObject.SetActive(true);
            Cosechar.gameObject.SetActive(true);
            Manzano.gameObject.SetActive(true);
            Naranjo.gameObject.SetActive(false);
            Comprar.gameObject.SetActive(false);
        }

        if (huerto && b.E1 && b.E2)
        {
            Mejorar.gameObject.SetActive(true);
            Cosechar.gameObject.SetActive(true);
            Manzano.gameObject.SetActive(true);
            Naranjo.gameObject.SetActive(true);
            Comprar.gameObject.SetActive(false);
        }
    }
    private void ads()
    {
        c.enabled = false;
        Time.timeScale = 1;
    }

    private void ComprarHueco()
    {
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
        ÁrbolManager5 a = Manager.GetComponent<ÁrbolManager5>();
        if (!huerto)
        {
            if (cont.monedas >= 25)
            {
                a.compraHuerto();
                huerto = true;
                cont.monedas -= 5;
                ads();
            }
        }
    }

    private void Plantar(int hue)
    {
        ÁrbolManager5 a = Manager.GetComponent<ÁrbolManager5>();
        guardar_Inventario g = player.GetComponent<guardar_Inventario>();
        switch (hue)
        {
            case 1:
                if (!a.plantado)
                {
                    var manzanaItem = g.inventario.Find(i => i.nombre == "Manzana");
                    if (manzanaItem != null && manzanaItem.count >= 1)
                    {
                        a.Plantar();
                        manzano = true;
                        manzanaItem.count -= 1;
                        ads();
                    }
                    else
                    {
                        Debug.Log("No tienes manzanas para plantar");
                    }

                }
                else
                {
                    Debug.Log("Ya esta plantado");
                }

                break;
            case 2:

                if (!a.plantado)
                {
                    var naranjaItem = g.inventario.Find(i => i.nombre == "Naranja");
                    if (naranjaItem != null && naranjaItem.count >= 1)
                    {
                        a.Plantar();
                        naranjo = true;
                        naranjaItem.count -= 1;
                        ads();
                    }
                    else
                    {
                        Debug.Log("No tienes naranjas para plantar");
                    }

                }
                else
                {
                    Debug.Log("Ya esta plantado");
                }

                break;
        }
    }

    private void CosechaR()
    {
        ÁrbolManager5 a = Manager.GetComponent<ÁrbolManager5>();
        guardar_Inventario g = player.GetComponent<guardar_Inventario>();
        if (a.fase == 2)
        {
            if (manzano)
            {
                g.AgregarItem("Manzana", null);
                g.AgregarItem("Manzana", null);
                if (mejorado)
                {
                    g.AgregarItem("Manzana", null);
                }
                a.fase = 0;
                a.plantado = false;
                Destroy(a.semi);
                manzano = false;
                huerto = false;
            }

            if (naranjo)
            {
                g.AgregarItem("Naranja", null);
                g.AgregarItem("Naranja", null);
                if (mejorado)
                {
                    g.AgregarItem("Naranja", null);
                }
                a.fase = 0;
                a.plantado = false;
                Destroy(a.semi);
                naranjo = false;
                huerto = false;
            }
        }
    }
    private void Mejoras()
    {
        Contador_Moneas cont = contmonedas.GetComponent<Contador_Moneas>();
        if (cont.monedas >= 50)
        {
            mejorado = true;
            cont.monedas -= 50;
            Mejorar.gameObject.SetActive(false);
        }
    }
    void Update()
    {

    }
}
