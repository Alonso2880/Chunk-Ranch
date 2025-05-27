using UnityEngine;

public class enemigo_goose : MonoBehaviour
{
    public float velocidad = 2f;        
    public float VelRot = 0.5f;           
    public float detectionDistance = 10f; 

    GameObject enemigo, player;

    private Vector3 E, J;

    void Start()
    {
        enemigo = this.gameObject;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
        E = enemigo.transform.position;
        J = player.transform.position;

        
        Vector3 directionToPlayer = (J - E).normalized;

        
        RaycastHit hit;
        if (Physics.Raycast(E, directionToPlayer, out hit, detectionDistance))
        {
            
            if (hit.transform.gameObject == player)
            {
                Perseguir(E, J, directionToPlayer);
            }
        }
    }

    private void Perseguir(Vector3 E, Vector3 J, Vector3 N)
    {
        
        transform.position = Vector3.MoveTowards(E, J, velocidad * Time.deltaTime);

        
        if (N != Vector3.zero)
        {
            Quaternion RotJugador = Quaternion.LookRotation(N);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, RotJugador, VelRot * Time.deltaTime);
        }
    }
}
