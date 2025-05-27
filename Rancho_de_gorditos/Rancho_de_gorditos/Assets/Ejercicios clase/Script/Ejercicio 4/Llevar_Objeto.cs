using UnityEngine;

public class Llevar_Objeto : MonoBehaviour
{
    [HideInInspector] public GameObject pelota;
    public Transform Objeto;
    private float fuerza = 10f;
    private bool v = false;
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            RecogerObjetos();
        }

        if (v)
        {
            if(Input.GetKeyUp(KeyCode.F))
            {
                TirarObjeto();
            }

            if (Input.GetKeyUp(KeyCode.R)){
                RotarObjeto();
            }
        }
    }

    public void RecogerObjetos()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("objeto"))
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

        Vector3 direclan = transform.forward;
        rb.AddForce(direclan*fuerza, ForceMode.Impulse);
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
