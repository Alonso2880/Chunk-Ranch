using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Vaca : MonoBehaviour
{
    GameObject vaca, lugarLeche, LecheL;
    private Rigidbody rb;
    private Vector3 velocidadVec;
    private float velocidad;
    private bool SeMueve = true, random = true;
    public bool enterreno = false;
    [HideInInspector] public bool b = false;
    private int X, Z, X1, tiempoLeche = 9;
    public int LecheTota = 0;
    public GameObject prefableche;

    [HideInInspector] public bool scriptActivo = true;
    private Coroutine movimientoCoroutine;
    private Coroutine LecheCoroutine;


    public delegate void ContadorLeche(int contcLeche);
    [HideInInspector] public static int multLeche = 1;

    guardar_Inventario g;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        velocidad = 2.5f;
        g = GameObject.Find("Player").GetComponent<guardar_Inventario>();
        LecheCoroutine = StartCoroutine("generarLeche");
        movimientoCoroutine = StartCoroutine("movimiento");
        lugarLeche = GameObject.Find("LugarLeche");

        LecheL = GameObject.Find("Leche");

    }

    private void OnDisable()
    {
        scriptActivo = false;

        if (movimientoCoroutine != null)
        {
            StopCoroutine(movimientoCoroutine);
        }

        if (LecheCoroutine != null)
        {
            StopCoroutine(LecheCoroutine);
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


    IEnumerator generarLeche()
    {


        while (scriptActivo)
        {
            if (!enterreno)
            {
                yield return null;
                continue;
            }
            yield return new WaitForSeconds(tiempoLeche);
            LecheTota += multLeche;
            Leche l = LecheL.GetComponent<Leche>();
            l.LecheTotal += LecheTota;
            ResetLeche();
        }
    }

    public void ResetLeche()
    {
        LecheTota = 0;
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

        if (collision.gameObject.CompareTag("T_Vacas"))
        {
            enterreno = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("T_Vacas"))
        {
            enterreno = false;
        }
    }
}
