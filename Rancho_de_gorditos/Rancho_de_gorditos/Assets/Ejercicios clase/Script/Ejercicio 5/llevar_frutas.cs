using UnityEngine;

public class llevar_frutas : MonoBehaviour
{
    [HideInInspector] public GameObject pelota;
    public Transform Objeto;
    private float fuerza = 10f;
    private bool v = false;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            RecogerObjetos();
        }

        if (v)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                TirarObjeto();
            }

            if (Input.GetKeyUp(KeyCode.R))
            {
                RotarObjeto();
            }
        }
    }

    public void RecogerObjetos()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("manzana"))
            {
                pelota = col.gameObject;

                pelota.transform.SetParent(Objeto);
                pelota.transform.position = Objeto.position;
                pelota.GetComponent<Rigidbody>().isKinematic = true;
                v = true;
                break;
            }

            if (col.CompareTag("limón"))
            {
                pelota = col.gameObject;

                pelota.transform.SetParent(Objeto);
                pelota.transform.position = Objeto.position;
                pelota.GetComponent<Rigidbody>().isKinematic = true;
                v = true;
                break;
            }

            if (col.CompareTag("sandía"))
            {
                pelota = col.gameObject;

                pelota.transform.SetParent(Objeto);
                pelota.transform.position = Objeto.position;
                pelota.GetComponent<Rigidbody>().isKinematic = true;
                v = true;
                break;
            }

            if (col.CompareTag("cereza"))
            {
                pelota = col.gameObject;

                pelota.transform.SetParent(Objeto);
                pelota.transform.position = Objeto.position;
                pelota.GetComponent<Rigidbody>().isKinematic = true;
                v = true;
                break;
            }
        }
    }


    public void TirarObjeto()
    {
        pelota.transform.SetParent(null);
        Rigidbody rb = pelota.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Vector3 direccionLanzamiento = Quaternion.Euler(0, -90, 0) * transform.forward;
        rb.AddForce(direccionLanzamiento * fuerza, ForceMode.Impulse);
        v = false;
    }

    public void RotarObjeto()
    {
        pelota.transform.SetParent(null);
        Rigidbody rb = pelota.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddTorque(Vector3.up * fuerza, ForceMode.Impulse);

        Vector3 direclan = transform.forward;
        rb.AddForce(direclan * fuerza, ForceMode.Impulse);
        v = false;
    }

}
