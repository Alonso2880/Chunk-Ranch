using System.Xml.Serialization;
using UnityEngine;

public class PendulumStarter : MonoBehaviour
{
    public float initialAngularSpeed = 5f;
    PendulumStarter p;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = new Vector3(0, 0, initialAngularSpeed);
        p.enabled = false;
    }

   
}
