using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiRayo : MonoBehaviour
{

    public Transform final; //Punto final
    public int cantidadDePuntos; //Cantidad de puntos 

    public float dispersion; //Dispersión del rayo
    public float frecuencia; //Cada cuantos segundo cambia la forma

    private LineRenderer line; //Herramienta para dibujar el rayo
    private float tiempo = 0;

    void Start()
    {
        line = GetLine();
        line.useWorldSpace = true;
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo > frecuencia) 
        {
            ActualizarPuntos(this.line);    //Actualiza la cantidad de puntos cada x segundos (frecuencia)
            tiempo = 0;
        }
    }

    private LineRenderer GetLine()
    {
        return GetComponent<LineRenderer>();
    }
    private void ActualizarPuntos(LineRenderer line) //Nueva lista de puntos
    {
        List<Vector3> puntos = InterpolarPuntos(transform.position, final.position, cantidadDePuntos);
        line.positionCount = puntos.Count;  
        line.SetPositions(puntos.ToArray());
    }

    private List<Vector3> InterpolarPuntos(Vector3 principio, Vector3 final, int totalPoints)
    {
        List<Vector3> list = new List<Vector3>();

        for (int i = 0; i < totalPoints; i++)
        {
            list.Add(Vector3.Lerp(principio, final, (float)i / totalPoints) + DesfaseAleatorio());
        }

        return list;
    }

    private Vector3 DesfaseAleatorio()
    {
        return Random.insideUnitSphere.normalized * Random.Range(0, dispersion);
    }
}
