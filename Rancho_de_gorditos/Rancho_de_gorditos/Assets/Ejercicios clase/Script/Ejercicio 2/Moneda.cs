using UnityEngine;

public class Moneda : MonoBehaviour
{
    GameObject moneda, jugador;
    void Start()
    {
        moneda = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugador = collision.gameObject;
        mov Jscript = jugador.GetComponent<mov>();
        if ( jugador.tag == "Player")
        {
            Jscript.vel = Jscript.vel +2f;
            Destroy(this.gameObject);   
        }
    }
}
