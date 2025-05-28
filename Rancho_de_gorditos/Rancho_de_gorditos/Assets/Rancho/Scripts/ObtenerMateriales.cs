using UnityEngine;

public class ObtenerMateriales : MonoBehaviour
{
    private GameObject jugador;
    public GameObject piedraMat;

    private bool colisionPiedra = false;
    private bool colisionMadera = false;

    private LlevarObjeto llevarObjeto;
    void Start()
    {
        jugador = this.gameObject;
        llevarObjeto = GetComponent<LlevarObjeto>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (colisionPiedra && llevarObjeto.picaPiedras)
            {
                RecogerMaterial("Roca", piedraMat, 2);
                Debug.Log("Has recogido roca");
            }

            if (colisionMadera && llevarObjeto.hacha)
            {
                RecogerMaterial("Madera", null, 2);
                Debug.Log("Has recogido madera");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piedra"))
        {
            colisionPiedra = true;
        }

        if (collision.gameObject.CompareTag("madera"))
        {
            colisionMadera = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Piedra"))
        {
            colisionPiedra = false;
        }

        if (collision.gameObject.CompareTag("madera"))
        {
            colisionMadera = false;
        }
    }


    private void RecogerMaterial(string nombre, GameObject prefab, int cantidad)
    {
        guardar_Inventario inventarioScript = this.GetComponent<guardar_Inventario>();
        for (int i=0; i<cantidad; i++)
        {
            inventarioScript.AgregarItem(nombre, prefab);
        }
    }
}
