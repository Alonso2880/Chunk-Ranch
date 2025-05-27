using UnityEngine;

public class Bloqueador_Carta2 : MonoBehaviour
{
    private GameObject Buzon, esto;
    private MeshRenderer m;
    private MeshCollider mc;
    void Start()
    {
        Buzon = GameObject.Find("MenuBuzón");
        esto = this.gameObject;
        m = esto.GetComponent<MeshRenderer>();
        mc = esto.GetComponent<MeshCollider>();
        m.enabled = false;
        mc.enabled = false;

    }


    void Update()
    {
        BuzónUI b = Buzon.GetComponent<BuzónUI>();
        if (b.E2)
        {
            m.enabled = true;
            mc.enabled = true;
        }

        if (!b.E2)
        {
            m.enabled = false;
            mc.enabled = false;
        }
    }
}
