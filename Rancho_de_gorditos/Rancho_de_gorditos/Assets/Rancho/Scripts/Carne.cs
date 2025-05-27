using UnityEngine;

public class Carne : MonoBehaviour
{
    GameObject carne;
    MeshRenderer CarneMesh;
    SphereCollider CarneColl;
    public int CarneTotal = 0;
    void Start()
    {
        carne = this.gameObject;
        CarneMesh = GetComponent<MeshRenderer>();
        CarneColl = GetComponent<SphereCollider>();
    }

    public void Reset()
    {
        CarneTotal = 0;
    }
    void Update()
    {
    }
}
