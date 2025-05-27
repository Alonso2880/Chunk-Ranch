using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class NewBehaviourScript : MonoBehaviour
{
    public static float multiplicadorVelocidad = 10.0f;
    public static float multiplicadorRotacion = 300.0f;

    private bool enSuelo;
    public float fuerzaSalto = 5.0f;
    private Rigidbody rb_jugador;
    

    public float listenerX, listenerY;

    void Start()
    {
        rb_jugador = GetComponent<Rigidbody>();

        rb_jugador.useGravity = true;
    }
    void Update()
    {
        // Captura del input
        listenerX = Input.GetAxis("Horizontal");
        listenerY = Input.GetAxis("Vertical");

        // Rotación en el eje Y
        float rotacionY = listenerX * multiplicadorRotacion * Time.deltaTime;
        transform.Rotate(0.0f, rotacionY, 0.0f);

        // Movimiento hacia adelante/atrás en el eje Z local
        float movimientoZ = listenerY * multiplicadorVelocidad * Time.deltaTime;
        transform.Translate(0.0f, 0.0f, movimientoZ);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb_jugador.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject colisionado = collision.gameObject;
        string tag_collisionado = colisionado.tag;

        // Verificar si está tocando el suelo
        if (tag_collisionado == "Suelo") // Etiqueta del suelo
        {
            enSuelo = true;
        }

      
    }

    private void OnCollisionExit(Collision collision)
    {
        // Dejar de estar en el suelo si sale de una colisión con el suelo
        if (collision.gameObject.tag == "Suelo")
        {
            enSuelo = false;
        }
    }
}