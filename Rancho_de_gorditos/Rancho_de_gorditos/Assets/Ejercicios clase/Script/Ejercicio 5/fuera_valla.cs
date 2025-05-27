using UnityEngine;

public class fuera_valla : MonoBehaviour
{
    private GameObject Valla;
    private MeshRenderer MV;
    private MeshCollider MeV;

    private void Start()
    {
        Valla = this.gameObject;
        
    }

    void Update()
    {
        
        if (!Cursor.visible || Cursor.lockState != CursorLockMode.None)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    private void OnMouseDown()
    {
        Desaparecer_Valla();
    }

    private void Desaparecer_Valla()
    {
        MV = Valla.GetComponent<MeshRenderer>();
        MeV = Valla.GetComponent<MeshCollider>();
        Debug.Log("Hola");
        MV.enabled = false;
        MeV.enabled = false;
    }
}
