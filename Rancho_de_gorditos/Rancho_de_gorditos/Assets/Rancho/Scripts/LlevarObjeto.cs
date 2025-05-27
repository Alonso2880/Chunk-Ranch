using System;
using Unity.Cinemachine;
using UnityEngine;

public class LlevarObjeto : MonoBehaviour
{
    public GameObject lugarSuc;
    [HideInInspector] public GameObject herramienta;
    public Transform Objeto;
    [HideInInspector] public bool v, picaPiedras = true, hacha = true;
    private float fuerza = 10f;
    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RecogerHerramienta();
        }
        if (v)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (picaPiedras)
                {
                    TirarObjeto();
                    picaPiedras = false;
                }

                if (hacha)
                {
                    TirarObjeto();
                    hacha = false;
                }
                
            }
        }
    }

    public void RecogerHerramienta()
    {
        Collider[] collides = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider col in collides)
        {
            if (col.CompareTag("PicaPiedras"))
            {
                herramienta = col.gameObject;

                herramienta.transform.SetParent(Objeto);
                herramienta.transform.position = Objeto.position;
                herramienta.GetComponent<Rigidbody>().isKinematic = true;
                v = true;
                picaPiedras = true;
               
                break;
            }

            if (col.CompareTag("Hacha"))
            {
                herramienta = col.gameObject;

                herramienta.transform.SetParent(Objeto);
                herramienta.transform.position = Objeto.position;
                herramienta.GetComponent<Rigidbody>().isKinematic = true;
                v = true;
                hacha = true;

                break;
            }
        }
    }

    public void TirarObjeto()
    {
        herramienta.transform.SetParent(null);
        Rigidbody rb = herramienta.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        Vector3 direclan = transform.forward;
        rb.AddForce(direclan * fuerza, ForceMode.Impulse);
        v = false;
        ;
    }

}
