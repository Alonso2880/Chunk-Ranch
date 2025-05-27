using UnityEngine;

public class casa : MonoBehaviour
{
    private GameObject player, huerto, casaUI;
    public int dia=0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        huerto = GameObject.FindGameObjectWithTag("huerto");
        casaUI = GameObject.Find("CasaUI");
    }


    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        CasaUI c = casaUI.GetComponent<CasaUI>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                c.abrir();
            }
            
            
        }
    }
}
