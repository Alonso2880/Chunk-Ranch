using UnityEngine;

public class Añadir_Mejorar_Parcela3 : MonoBehaviour
{
    public GameObject parcela, terreno, parcelaGrande, recogidaH, gallinero, recogidaL, recogidaC, recogidaLe;
    private GameObject MenuParcela;
    public Transform punto, punto_grande, puntoRecogida, puntoGallinero, puntoGalli2;
    [HideInInspector] public GameObject parcelaPrefab, recogidaPrefab, gallineroPrefab;
    [HideInInspector] public bool hayParcela;
    void Start()
    {
        MenuParcela = GameObject.Find("MenuParcelas3");
    }

    public void GenerarParcelaGallina()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        recogidaPrefab =Instantiate(recogidaH, puntoRecogida.position, puntoRecogida.rotation);
        recogidaPrefab.transform.SetParent(puntoRecogida);
        gallineroPrefab = Instantiate(gallinero, puntoGallinero.position, puntoGallinero.rotation);
        gallineroPrefab.transform.SetParent(puntoGallinero);
        hayParcela = true;
    }

    public void GenerarParcelaVaca()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        recogidaPrefab = Instantiate(recogidaLe, puntoRecogida.position, puntoRecogida.rotation);
        recogidaPrefab.transform.SetParent(puntoRecogida);

        recogidaPrefab.transform.localRotation = Quaternion.Euler(recogidaPrefab.transform.localEulerAngles.x, recogidaPrefab.transform.localEulerAngles.y, 145f);

        Vector3 pos = recogidaPrefab.transform.localPosition;
        pos.z = 0.56f;
        recogidaPrefab.transform.localPosition = pos;

        hayParcela = true;
    }

    public void GenerarParcelaCerdo()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        recogidaPrefab = Instantiate(recogidaC, puntoRecogida.position, puntoRecogida.rotation);
        recogidaPrefab.transform.SetParent(puntoRecogida);
        hayParcela = true;
    }

    public void GenerarParcelaOveja()
    {
        parcelaPrefab = Instantiate(parcela, punto.position, punto.rotation);
        parcelaPrefab.transform.SetParent(punto);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        recogidaPrefab = Instantiate(recogidaL, puntoRecogida.position, puntoRecogida.rotation);
        recogidaPrefab.transform.SetParent(puntoRecogida);
        hayParcela = true;
    }

    public void AmpliarParcela()
    {
        Destroy(parcelaPrefab);
        terreno.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        parcelaPrefab = Instantiate(parcelaGrande, punto_grande.position, punto_grande.rotation);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        parcelaPrefab.transform.SetParent(punto_grande);

        Destroy(gallineroPrefab);
        gallineroPrefab = Instantiate(gallinero, puntoGalli2.position, puntoGalli2.rotation);
        gallineroPrefab.transform.SetParent(puntoGalli2);

    }

    public void AmpliarParcelaResto()
    {
        Destroy(parcelaPrefab);
        terreno.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        parcelaPrefab = Instantiate(parcelaGrande, punto_grande.position, punto_grande.rotation);
        parcelaPrefab.transform.localScale = Vector3.one * 0.9f;
        parcelaPrefab.transform.SetParent(punto_grande);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Menu_Parcelas3 m = MenuParcela.GetComponent<Menu_Parcelas3>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

}
