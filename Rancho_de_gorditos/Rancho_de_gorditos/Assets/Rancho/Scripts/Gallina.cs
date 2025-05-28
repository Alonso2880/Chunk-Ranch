using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Gallina : MonoBehaviour
{
    GameObject gallina, lugarHuevo, huevoG;
    private Rigidbody rb;
    private Vector3 velocidadVec;
    private float velocidad;
    private bool SeMueve = true, random = true;
    public bool enterreno = false;
    [HideInInspector] public bool b = false;
    public int X, Z, X1, tiempoHuevo = 5;
    public int huevoTota = 0;
    public GameObject prefabHuevo;

    [HideInInspector] public bool scriptActivo = true;
    private Coroutine movimientoCoroutine;
    private Coroutine huevoCoroutine;


    public delegate void ContadorHuevo(int conthuevo);
    [HideInInspector] public static int multHuevo=1;

    guardar_Inventario g;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 2.5f;
        g = GameObject.Find("Player").GetComponent<guardar_Inventario>();
        huevoCoroutine = StartCoroutine("generarHuevo");
        movimientoCoroutine = StartCoroutine("movimiento");
        lugarHuevo = GameObject.Find("LugarHuevo");

        huevoG = GameObject.Find("Huevo");
       
    }

    private void OnDisable()
    {
        scriptActivo = false;

        if (movimientoCoroutine != null)
        {
            StopCoroutine(movimientoCoroutine);
        }

        if (huevoCoroutine != null)
        {
            StopCoroutine(huevoCoroutine);
        }
        random = true;
        SeMueve = false;
    }


    IEnumerator movimiento()
    {
        while (scriptActivo)
        {
            if (SeMueve)
            {
                if (!scriptActivo) yield break;
                velocidadVec = new Vector3(X, 0, Z).normalized * velocidad;
                rb.linearVelocity = new Vector3(velocidadVec.x, rb.linearVelocity.y, velocidadVec.z);
                yield return new WaitForSeconds(3);
                SeMueve = false;
                random = true;
            }
            else
            {
                rb.linearVelocity = Vector3.zero;
                yield return new WaitForSeconds(1);
                SeMueve = true;
            }
        }


    }


    IEnumerator generarHuevo()
    {
        
        
        while (scriptActivo)
        {
            if (!enterreno)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(tiempoHuevo);
            huevoTota += multHuevo;
            huevo h = huevoG.GetComponent<huevo>();
            h.HuevoTotal += huevoTota;
            ResetHuevos();
        }
    }

    public void ResetHuevos()
    {
        huevoTota = 0;
    }

    void FixedUpdate()
    {


        if (random && scriptActivo)
        {
            X = Random.Range(-1, 2);
            Z = Random.Range(-1, 2);
            X1 = Random.Range(1, 3);
            random = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (scriptActivo && collision.gameObject.CompareTag("Valla"))
        {
            X = Random.Range(-1, 2);
            Z = Random.Range(-1, 2);
        }

        if (collision.gameObject.CompareTag("T_Gallinas"))
        {
            enterreno = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("T_Gallinas"))
        {
            enterreno = false;
        }
    }
}