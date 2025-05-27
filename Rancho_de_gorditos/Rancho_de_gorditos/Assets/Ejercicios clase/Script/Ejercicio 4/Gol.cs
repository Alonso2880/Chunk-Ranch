using System.Collections;
using UnityEngine;

public class Gol : MonoBehaviour
{
    public GameObject pendulo;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        PendulumStarter p = pendulo.GetComponent<PendulumStarter>();
        if (collision.gameObject.CompareTag("Finish"))
            {
            p.enabled = true;
            StartCoroutine("Parar");
        }
    }
    IEnumerator Parar()
    {
        PendulumStarter p = pendulo.GetComponent<PendulumStarter>();
        yield return new WaitForSeconds(5);
        p.enabled = false;
    }
    void Update()
    {
        
    }
}
