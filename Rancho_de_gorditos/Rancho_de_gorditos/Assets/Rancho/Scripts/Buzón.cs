using UnityEngine;

public class Buzón : MonoBehaviour
{
    private GameObject buzonUI;
    void Start()
    {
        buzonUI = GameObject.Find("MenuBuzón");
    }

    private void OnCollisionStay(Collision collision)
    {
        BuzónUI b = buzonUI.GetComponent<BuzónUI>();
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                b.abrir();
            }
            
        }
    }
}
