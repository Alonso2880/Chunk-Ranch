using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Coger_Animales : MonoBehaviour
{
    GameObject player;
    Gallina gallina;
    public GameObject gallinaPrefab, cerdoPrefab, vacaPrefab, ovejaPrefab;
    public Transform puntoSujección;
    public float fuerzaLanzamiento = 10f;
    public Animator animator;

    [HideInInspector] public GameObject gallinaActual, cerdoActual, vacaActual, ovejaActual;
    [HideInInspector] public bool tieneGallina = false, tieneCerdo = false, tieneOveja = false, tieneVaca = false, g=false, c= false, v=false, o=false;
    void Start()
    {
        player = this.gameObject;
        gallina = GameObject.Find("Pollo").GetComponent<Gallina>();
    }


    void Update()
    {
        if (tieneGallina)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarGallina();
                animator.SetBool("CogerW", false);
            }
        }
        if (tieneCerdo)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarCerdo();
                animator.SetBool("CogerW", false);
            }
        }
        if (tieneOveja)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarOveja();
                animator.SetBool("CogerW", false);
            }
        }
        if (tieneVaca)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LanzarVaca();
                animator.SetBool("CogerW", false);
            }
        }

        if (g && !c && !o && !v)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerGallina();
                animator.SetBool("CogerW", true);
            }
        }

        if (c && !g && !o && !v)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerCerdo();
                animator.SetBool("CogerW", true);
            }
        }

        if (o && !g && !v && !c)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerOveja();
                animator.SetBool("CogerW", true);
            }
        }

        if (v && !g && !c && !o)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                RecogerVaca();
                animator.SetBool("CogerW", true);
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gallina"))
        {
            g = true;
        }

        if (collision.gameObject.CompareTag("Cerdo"))
        {
            c = true;
        }

        if (collision.gameObject.CompareTag("Oveja"))
        {
            o = true;
        }

        if (collision.gameObject.CompareTag("Vaca"))
        {
            v = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gallina"))
        {
            g = false;
        }

        if (collision.gameObject.CompareTag("Cerdo"))
        {
            c = false;
        }

        if (collision.gameObject.CompareTag("Oveja"))
        {
            o = false;
        }

        if (collision.gameObject.CompareTag("Vaca"))
        {
            v = false;
        }
    }

    //Obtener
    public void ObtenerGallina()
    {
        gallinaActual = Instantiate(gallinaPrefab, puntoSujección.position, puntoSujección.rotation);
        gallinaActual.transform.SetParent(puntoSujección);
        gallinaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneGallina = true;
    }

    public void ObtenerCerdo()
    {
        cerdoActual = Instantiate(cerdoPrefab, puntoSujección.position, puntoSujección.rotation);
        cerdoActual.transform.SetParent(puntoSujección);
        cerdoActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = cerdoActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneCerdo = true;
    }

    public void ObtenerOveja()
    {
        ovejaActual = Instantiate(ovejaPrefab, puntoSujección.position, puntoSujección.rotation);
        ovejaActual.transform.SetParent(puntoSujección);
        ovejaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = ovejaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneOveja = true;
    }

    public void ObtenerVaca()
    {
        vacaActual = Instantiate(vacaPrefab, puntoSujección.position, puntoSujección.rotation);
        vacaActual.transform.SetParent(puntoSujección);
        vacaActual.GetComponent<Rigidbody>().isKinematic = true;

        Gallina scriptGallina = vacaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = false;
        }

        tieneVaca = true;
    }

    //Lanzar
    private void LanzarGallina()
    {
        gallinaActual.transform.SetParent(null);
        Rigidbody rb = gallinaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
        if (scriptGallina != null)
        {
            scriptGallina.enabled = true;
            scriptGallina.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);
        
        tieneGallina = false;
    }

    private void LanzarCerdo()
    {
        cerdoActual.transform.SetParent(null);
        Rigidbody rb = cerdoActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Cerdo scriptCerdo = cerdoActual.GetComponent<Cerdo>();
        if (scriptCerdo != null)
        {
            scriptCerdo.enabled = true;
            scriptCerdo.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);

        tieneCerdo = false;
    }

    private void LanzarOveja()
    {
        ovejaActual.transform.SetParent(null);
        Rigidbody rb = ovejaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Oveja scriptOveja = ovejaActual.GetComponent<Oveja>();
        if (scriptOveja != null)
        {
            scriptOveja.enabled = true;
            scriptOveja.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);

        tieneOveja = false;
    }

    private void LanzarVaca()
    {
        vacaActual.transform.SetParent(null);
        Rigidbody rb = vacaActual.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        string scene = SceneManager.GetActiveScene().name;

        Vaca scriptVaca = vacaActual.GetComponent<Vaca>();
        if (scriptVaca != null)
        {
            scriptVaca.enabled = true;
            scriptVaca.scriptActivo = true;
        }

        Vector3 direccionLanzamiento = transform.forward;
        rb.AddForce(direccionLanzamiento * fuerzaLanzamiento, ForceMode.Impulse);

        tieneVaca = false;
    }


    //Recoger
    private void RecogerGallina()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Gallina") && !tieneGallina)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");
                

                gallinaActual = col.gameObject;

                Gallina scriptGallina = gallinaActual.GetComponent<Gallina>();
                if (scriptGallina != null)
                {
                    scriptGallina.enabled = false;
                }

                gallinaActual.transform.SetParent(puntoSujección);
                gallinaActual.transform.position = puntoSujección.position;
                gallinaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneGallina = true;
                g = false;
                break;
            }
        }
    }

    private void RecogerCerdo()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Cerdo") && !tieneCerdo)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");


                cerdoActual = col.gameObject;

                Cerdo scriptCerdo = cerdoActual.GetComponent<Cerdo>();
                if (scriptCerdo != null)
                {
                    scriptCerdo.enabled = false;
                }

                cerdoActual.transform.SetParent(puntoSujección);
                cerdoActual.transform.position = puntoSujección.position;
                cerdoActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneCerdo = true;
                c = false;
                break;
            }
        }
    }

    private void RecogerOveja()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Oveja") && !tieneOveja)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");


                ovejaActual = col.gameObject;

                Oveja scriptOveja = ovejaActual.GetComponent<Oveja>();
                if (scriptOveja != null)
                {
                    scriptOveja.enabled = false;
                }

                ovejaActual.transform.SetParent(puntoSujección);
                ovejaActual.transform.position = puntoSujección.position;
                ovejaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneOveja = true;
                o = false;
                break;
            }
        }
    }

    private void RecogerVaca()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("Vaca") && !tieneVaca)
            {
                string escena = SceneManager.GetActiveScene().name;
                string prefabName = col.gameObject.name.Replace("(Clone)", "");


                vacaActual = col.gameObject;

                Vaca scriptVaca = vacaActual.GetComponent<Vaca>();
                if (scriptVaca != null)
                {
                    scriptVaca.enabled = false;
                }

                vacaActual.transform.SetParent(puntoSujección);
                vacaActual.transform.position = puntoSujección.position;
                vacaActual.GetComponent<Rigidbody>().isKinematic = true;
                tieneVaca = true;
                v = false;
                break;
            }
        }
    }

}
