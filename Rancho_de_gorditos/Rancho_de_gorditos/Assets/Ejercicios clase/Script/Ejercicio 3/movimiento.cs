using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float vel;
    private float cordX, cordZ;
    private Vector3 pos;    void Start()
    {
    }

  
    void Update()
    {
     

        cordX = Input.GetAxis("Horizontal");
        cordZ = Input.GetAxis("Vertical");
        pos = new Vector3(cordX, 0, cordZ);

        transform.Translate(pos * vel * Time.deltaTime);
    }
}
