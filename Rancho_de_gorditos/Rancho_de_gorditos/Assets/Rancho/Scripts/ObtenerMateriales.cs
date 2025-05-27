using UnityEngine;

public class ObtenerMateriales : MonoBehaviour
{
    private GameObject jugador, piedra, madera;
    public GameObject piedraMat;
    void Start()
    {
        jugador = this.gameObject;
        
    }

    private void picarPiedra()
    {
        LlevarObjeto l = jugador.GetComponent<LlevarObjeto>();
        guardar_Inventario inventarioScript = this.GetComponent<guardar_Inventario>();
        if (l.picaPiedras)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                inventarioScript.AgregarItem("Roca", piedraMat);
                Debug.Log("Me muero");
                piedra = null;
            }
        }
    }

    private void cortarMadera()
    {

        LlevarObjeto l = jugador.GetComponent<LlevarObjeto>();
        guardar_Inventario inventarioScript = this.GetComponent<guardar_Inventario>();

        if (l.hacha)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventarioScript.AgregarItem("Madera", null);
                inventarioScript.AgregarItem("Madera", null);
                Debug.Log("Me muero");
                madera = null;

            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        LlevarObjeto l = jugador.GetComponent<LlevarObjeto>();
        guardar_Inventario inventarioScript = this.GetComponent<guardar_Inventario>();

        if (collision.gameObject.CompareTag("Piedra"))
        {
            
            piedra = collision.gameObject;
            // picarPiedra();
            if (l.picaPiedras)
            {

                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventarioScript.AgregarItem("Roca", piedraMat);
                    Debug.Log("Me muero");
                    piedra = null;
                }
            }

        }

        if (collision.gameObject.CompareTag("madera"))
        {
            //Debug.Log("hh");
            madera = collision.gameObject;
            // cortarMadera();

            if (l.hacha)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inventarioScript.AgregarItem("Madera", null);
                    inventarioScript.AgregarItem("Madera", null);
                    Debug.Log("Me muero");
                    madera = null;

                }
            }
        }
    }
}
