using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    GameObject jugador, contMonedas, MenuV;
    int monedasT = 0;


    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player");
        contMonedas = GameObject.Find("Canvas");
        MenuV = GameObject.Find("MenuVender");
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Menu_Vender m = MenuV.GetComponent<Menu_Vender>();
        if (collision.gameObject.CompareTag("Player"))
        {
            m.AbrirMenu();
        }
    }

    public void Huevo(int cantidadAVender)
    {
        var inventario = jugador.GetComponent<guardar_Inventario>().inventario;
        var contador = contMonedas.GetComponent<Contador_Moneas>();

        foreach (InventoryItemData item in inventario)
        {
            if (item.nombre != "Huevo" || cantidadAVender <= 0)
                continue;


            int vendibles = Mathf.Min(cantidadAVender, item.count);

            item.count -= vendibles;

            contador.monedas += vendibles;

            cantidadAVender -= vendibles;

            if (cantidadAVender <= 0)
                break;
        }
    }

    public void Carne(int cantidadAVender)
    {
        var inventario = jugador.GetComponent<guardar_Inventario>().inventario;
        var contador = contMonedas.GetComponent<Contador_Moneas>();

        foreach (InventoryItemData item in inventario)
        {
            if (item.nombre != "Carne" || cantidadAVender <= 0)
                continue;


            int vendibles = Mathf.Min(cantidadAVender, item.count);

            item.count -= vendibles;

            contador.monedas += vendibles*2;

            cantidadAVender -= vendibles;

            if (cantidadAVender <= 0)
                break;
        }
    }

    public void Leche(int cantidadAVender)
    {
        var inventario = jugador.GetComponent<guardar_Inventario>().inventario;
        var contador = contMonedas.GetComponent<Contador_Moneas>();

        foreach (InventoryItemData item in inventario)
        {
            if (item.nombre != "Leche" || cantidadAVender <= 0)
                continue;


            int vendibles = Mathf.Min(cantidadAVender, item.count);

            item.count -= vendibles;

            contador.monedas += vendibles*3;

            cantidadAVender -= vendibles;

            if (cantidadAVender <= 0)
                break;
        }
    }

    public void Lana(int cantidadAVender)
    {
        var inventario = jugador.GetComponent<guardar_Inventario>().inventario;
        var contador = contMonedas.GetComponent<Contador_Moneas>();

        foreach (InventoryItemData item in inventario)
        {
            if (item.nombre != "Lana" || cantidadAVender <= 0)
                continue;


            int vendibles = Mathf.Min(cantidadAVender, item.count);

            item.count -= vendibles;

            contador.monedas += vendibles*4;

            cantidadAVender -= vendibles;

            if (cantidadAVender <= 0)
                break;
        }
    }
}

