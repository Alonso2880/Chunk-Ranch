using UnityEngine;
using UnityEngine.UI;
public class JournalUI : MonoBehaviour
{
    public Button b;
    public GameObject inventario;
    void Start()
    {
        b.onClick.AddListener(() => jour());
    }

    public void jour()
    {
        InventoryUI i = inventario.GetComponent<InventoryUI>();
        i.c.enabled = true;
    }
    
    void Update()
    {
        
    }
}
