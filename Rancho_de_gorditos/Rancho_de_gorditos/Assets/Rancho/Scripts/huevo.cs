using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class huevo : MonoBehaviour
{
    GameObject Huevo;
    MeshRenderer HuevoMesh;
    SphereCollider HuevoColl;
    public int HuevoTotal=0;
    void Start()
    {
        Huevo = this.gameObject;
        HuevoMesh = GetComponent<MeshRenderer>();
        HuevoColl = GetComponent<SphereCollider>();
    }

    public void Reset()
    {
        HuevoTotal = 0;
    }
    void Update()
    {
    }
}
