using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Cerdo : MonoBehaviour
{
    GameObject cerdo, lugarCarne, CarneC;
    private Rigidbody rb;
    private Vector3 velocidadVec;
    private float velocidad;
    private bool SeMueve = true, random = true;
    public bool enterreno = false;
    [HideInInspector] public bool b = false;
    public int X, Z, X1, tiempoCarne = 7;
    public int carneTota = 0;
    public GameObject prefabcarne;

    [HideInInspector] public bool scriptActivo = true;
    private Coroutine movimientoCoroutine;
    private Coroutine carneCoroutine;


    public delegate void ContadorCarne(int contcarne);
    [HideInInspector] public static int multcarne = 1;

    guardar_Inventario g;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 2.5f;
        g = GameObject.Find("Player").GetComponent<guardar_Inventario>();
        carneCoroutine = StartCoroutine("generarCarne");
        movimientoCoroutine = StartCoroutine("movimiento");
        lugarCarne = GameObject.Find("LugarCarne");

        CarneC = GameObject.Find("Carne");

    }

    private void OnDisable()
    {
        scriptActivo = false;

        if (movimientoCoroutine != null)
        {
            StopCoroutine(movimientoCoroutine);
        }

        if (carneCoroutine != null)
        {
            StopCoroutine(carneCoroutine);
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


    IEnumerator generarCarne()
    {


        while (scriptActivo)
        {
            if (!enterreno)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(tiempoCarne);
            carneTota += multcarne;
            Carne c = CarneC.GetComponent<Carne>();
            c.CarneTotal += carneTota;
            Resetcarne();
        }
    }

    public void Resetcarne()
    {
        carneTota = 0;
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

        if (collision.gameObject.CompareTag("T_Cerdos"))
        {
            enterreno = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("T_Cerdos"))
        {
            enterreno = false;
        }
    }
}
