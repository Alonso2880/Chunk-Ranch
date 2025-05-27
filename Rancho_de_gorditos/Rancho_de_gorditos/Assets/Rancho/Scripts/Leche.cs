using UnityEngine;

public class Leche : MonoBehaviour
{
    GameObject leche;
    MeshRenderer LecheMesh;
    SphereCollider LecheColl;
    public int LecheTotal = 0;
    void Start()
    {
        leche = this.gameObject;
        LecheMesh = GetComponent<MeshRenderer>();
        LecheColl = GetComponent<SphereCollider>();
    }

    public void Reset()
    {
        LecheTotal = 0;
    }
    void Update()
    {
    }
}
