using UnityEngine;

public class Lana : MonoBehaviour
{
    GameObject lana;
    MeshRenderer LanaMesh;
    SphereCollider LanaColl;
    public int LanaTotal = 0;
    void Start()
    {
        lana = this.gameObject;
        LanaMesh = GetComponent<MeshRenderer>();
        LanaColl = GetComponent<SphereCollider>();
    }

    public void Reset()
    {
        LanaTotal = 0;
    }
    void Update()
    {
    }
}
