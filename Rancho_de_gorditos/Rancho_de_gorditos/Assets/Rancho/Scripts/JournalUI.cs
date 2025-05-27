using UnityEngine;
using UnityEngine.UI;
public class JournalUI : MonoBehaviour
{
    public Button b, tutorial, hechizos, salirT, salirH;
    public GameObject inventario;
    public Image hechi, tuto;
    void Start()
    {
        b.onClick.AddListener(() => jour());
        tutorial.onClick.AddListener(() => Tutorial());
        hechizos.onClick.AddListener(() => Runas());
        hechi.gameObject.SetActive(false);
        tuto.gameObject.SetActive(false);
        salirH.onClick.AddListener(() => adsH());
        salirT.onClick.AddListener(() => adsT());
        salirH.gameObject.SetActive(false);
        salirT.gameObject.SetActive(false);
        
    }

    public void jour()
    {
        InventoryUI i = inventario.GetComponent<InventoryUI>();
        i.c.enabled = true;
    }

    public void adsH()
    {
        hechi.gameObject.SetActive(false);
        salirH.gameObject.SetActive(false);
    }

    public void adsT()
    {
        tuto.gameObject.SetActive(false);
        salirT.gameObject.SetActive(false);
    }

    public void Tutorial()
    {
        tuto.gameObject.SetActive(true);
        salirT.gameObject.SetActive(true);

    }

    public void Runas()
    {
        hechi.gameObject.SetActive(true);
        salirH.gameObject.SetActive(true);
    }
    
    void Update()
    {
        
    }
}
