using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cesta : MonoBehaviour
{
    private int contador = 0;
    public Canvas canva;
    public GameObject sandía;
    public GameObject cereza;
    public GameObject manzana;
    public GameObject limón;
   

    private void Start()
    {
        
    }
    void Update()
    {
        felicidades f = canva.GetComponent<felicidades>();
        if(contador >= 4)
        {
            f.ya = true;
        }
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("cereza"))
        {
            contador++;
            Destroy(cereza);
        }
        if (collision.gameObject.CompareTag("manzana"))
        {
            contador++;
            Destroy(manzana);
        }
        if (collision.gameObject.CompareTag("sandía"))
        {
            contador++;
            Destroy(sandía);
        }
        if (collision.gameObject.CompareTag("limón"))
        {
            contador++;
            Destroy(limón);
        }
    }


}
