using UnityEngine;
using UnityEngine.SceneManagement;

public class ene : MonoBehaviour
{
    public GameObject jugador;
    private int vida = 4;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(vida <= 0)
        {
            Destroy(jugador);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vida -= 1;
        }
    }
}
