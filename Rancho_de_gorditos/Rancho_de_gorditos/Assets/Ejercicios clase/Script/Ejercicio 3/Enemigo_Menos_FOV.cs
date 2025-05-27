using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemigo_Menos_FOV : MonoBehaviour
{
    public float velocidad, VelRot;
    GameObject enemigo, player;

    private Vector3 E, J, result, E1;
    float dot;
    void Start()
    {
        velocidad = 2;
        enemigo = this.gameObject;
        player = GameObject.FindWithTag("Player");
    }


    void Update()
    {
        E = enemigo.transform.position;
        J = player.transform.position;
        E1 = enemigo.transform.forward;

        result = J - E;
        Vector3 normalizadorR = result.normalized;
        dot = Vector3.Dot(normalizadorR, E1);
        Debug.Log(dot);

        if (dot >=  0.7 && dot <= 1)
        {
            Perseguir(E, J, normalizadorR);
        }

    }

    private void Perseguir(Vector3 E, Vector3 J, Vector3 N)
    {
        transform.position = Vector3.MoveTowards(E, J, velocidad * Time.deltaTime);
        VelRot = 0.5f;

        Vector3 direction = N;
        if (direction != Vector3.zero)
        {
            Quaternion RotJugador = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotJugador, VelRot * Time.deltaTime);
        }
    }
}
