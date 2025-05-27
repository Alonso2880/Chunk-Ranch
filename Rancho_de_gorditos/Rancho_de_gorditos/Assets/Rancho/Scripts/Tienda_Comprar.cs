using System.Runtime.CompilerServices;
using UnityEngine;

public class Tienda_Comprar : MonoBehaviour
{
    [HideInInspector] public GameObject jugador, contMonedas, menu_compra;
    


    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        contMonedas = GameObject.Find("Canvas");
        menu_compra = GameObject.Find("MenuCompra");
       

    }

   
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Menu_Compra m1 = menu_compra.GetComponent<Menu_Compra>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m1.AbrirMenu();
        }
        
        

    }

    public void Gallina()
    {
        Coger_Animales jscript = jugador.GetComponent<Coger_Animales>();
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
        if (!jscript.tieneGallina)
        {
            if (cont.monedas < 4)
            {
                Debug.Log("Monedas insuficientes");
            }
            else
            {
                Debug.Log("Comprado una gallina por 4 monedas");
                cont.monedas -= 4;
                jscript.ObtenerGallina();
            }
        }
    }

    public void Cerdo()
    {
        Coger_Animales jscript = jugador.GetComponent<Coger_Animales>();
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
        if (!jscript.tieneCerdo)
        {
            if (cont.monedas < 4)
            {
                Debug.Log("Monedas insuficientes");
            }
            else
            {
                Debug.Log("Comprado un cerdo por 4 monedas");
                cont.monedas -= 4;
                jscript.ObtenerCerdo();
            }
        }
    }

    public void Oveja()
    {
        Coger_Animales jscript = jugador.GetComponent<Coger_Animales>();
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
        if (!jscript.tieneOveja)
        {
            if (cont.monedas < 4)
            {
                Debug.Log("Monedas insuficientes");
            }
            else
            {
                Debug.Log("Comprado una oveja por 4 monedas");
                cont.monedas -= 4;
                jscript.ObtenerOveja();
            }
        }
    }

    public void Vaca()
    {
        Coger_Animales jscript = jugador.GetComponent<Coger_Animales>();
        Contador_Moneas cont = contMonedas.GetComponent<Contador_Moneas>();
        if (!jscript.tieneVaca)
        {
            if (cont.monedas < 4)
            {
                Debug.Log("Monedas insuficientes");
            }
            else
            {
                Debug.Log("Comprado una vaca por 4 monedas");
                cont.monedas -= 4;
                jscript.ObtenerVaca();
            }
        }
    }
}
