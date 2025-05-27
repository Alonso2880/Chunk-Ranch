using UnityEngine;

public class Rotar : MonoBehaviour
{
    GameObject rotar, jugador;
    private bool Rot=false;
    private int velRot;
    void Start()
    {
        rotar = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player");
        velRot = 100;
    }

    
    void FixedUpdate()
    {
        if(Rot == true)
        {
            float rotation = velRot * Time.fixedDeltaTime;
            transform.Rotate(Vector3.up, rotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugador = collision.gameObject;
        if(jugador.tag == "Player")
        {
            Rot = true;
        }
    }
}
