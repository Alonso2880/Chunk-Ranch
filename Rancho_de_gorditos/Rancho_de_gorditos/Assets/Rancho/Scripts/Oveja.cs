using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Oveja : MonoBehaviour
{
    GameObject oveja, lugarLana, LanaL;
    private Rigidbody rb;
    private Vector3 velocidadVec;
    private float velocidad;
    private bool SeMueve = true, random = true;
    public bool enterreno = false;
    [HideInInspector] public bool b = false;
    private int X, Z, X1, tiempoLana = 11;
    public int LanaTota = 0;
    public GameObject prefabLana;

    [HideInInspector] public bool scriptActivo = true;
    private Coroutine movimientoCoroutine;
    private Coroutine LanaCoroutine;


    public delegate void ContadorLLana(int contcLana);
    [HideInInspector] public static int multLana = 1;

    guardar_Inventario g;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 2.5f;
        g = GameObject.Find("Player").GetComponent<guardar_Inventario>();
        LanaCoroutine = StartCoroutine("generarLana");
        movimientoCoroutine = StartCoroutine("movimiento");
        lugarLana = GameObject.Find("LugarLana");

        LanaL = GameObject.Find("Lana");

    }

    private void OnDisable()
    {
        scriptActivo = false;

        if (movimientoCoroutine != null)
        {
            StopCoroutine(movimientoCoroutine);
        }

        if (LanaCoroutine != null)
        {
            StopCoroutine(LanaCoroutine);
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


    IEnumerator generarLana()
    {
        while (scriptActivo)
        {
            if (!enterreno)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(tiempoLana);
            LanaTota += multLana;
            Lana l = LanaL.GetComponent<Lana>();
            l.LanaTotal += LanaTota;
            ResetLeche();
        }
    }

    public void ResetLeche()
    {
        LanaTota = 0;
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

        if (collision.gameObject.CompareTag("T_Ovejas"))
        {
            enterreno = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("T_Ovejas"))
        {
            enterreno = false;
        }
    }
}
