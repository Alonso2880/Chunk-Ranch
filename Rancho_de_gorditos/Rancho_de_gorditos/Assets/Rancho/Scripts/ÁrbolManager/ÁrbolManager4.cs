using UnityEngine;

public class ÁrbolManager4 : MonoBehaviour
{
    public GameObject semillaPrefab, brotePrefab, Manzano, Naranjo, hueco, huecoHuerto, huerto;
    private GameObject player, ÁrbolUI, Casa;
    [HideInInspector] public bool plantado = false;
    private int dia = 0;
    public int fase = 0;
    [HideInInspector] public GameObject semi;
    void Start()
    {
        player = GameObject.Find("Player");
        ÁrbolUI = GameObject.Find("ÁrbolUI4");
        Casa = GameObject.Find("CasaBrujita");
    }

    private void Update()
    {
        Crecer();
    }

    public void compraHuerto()
    {
        Instantiate(huerto, huecoHuerto.transform.position, huecoHuerto.transform.rotation);
    }

    public void Plantar()
    {
        semi = Instantiate(semillaPrefab, hueco.transform);
        semi.transform.localPosition = new Vector3(0f, 0f, 0.026f);
        semi.transform.localRotation = Quaternion.identity;
        plantado = true;
    }

    private void Crecer()
    {
        casa c = Casa.GetComponent<casa>();
        ÁrbolUI4 a = ÁrbolUI.GetComponent<ÁrbolUI4>();
        if (c.dia != dia)
        {
            if (plantado)
            {
                if (fase == 0)
                {
                    Destroy(semi);
                    semi = Instantiate(brotePrefab, hueco.transform);
                    semi.transform.localPosition = new Vector3(0f, 0f, 0.443f);
                    semi.transform.localRotation = Quaternion.identity;
                    fase++;
                    dia = c.dia;
                    return;
                }

                if (fase == 1)
                {
                    if (a.manzano)
                    {
                        Destroy(semi);
                        semi = Instantiate(Manzano, hueco.transform);
                        semi.transform.localPosition = new Vector3(0f, 0f, 2.62f);
                        semi.transform.localRotation = Quaternion.identity;
                        fase++;
                        dia = c.dia;
                    }

                    if (a.naranjo)
                    {
                        Destroy(semi);
                        semi = Instantiate(Naranjo, hueco.transform);
                        semi.transform.localPosition = new Vector3(0f, 0f, 2.131f);
                        semi.transform.localRotation = Quaternion.identity;
                        fase++;
                        dia = c.dia;
                    }
                }


            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        ÁrbolUI4 a = ÁrbolUI.GetComponent<ÁrbolUI4>();
        if (collision.gameObject.CompareTag("Player"))
        {
            a.hola();
        }
    }
}
