using UnityEngine;
using UnityEngine.UI;

public class AjustesUI : MonoBehaviour
{
    public Canvas can;
    public Button volver, inventario, cartas;
    private GameObject MP, InvenUI;
    public Slider volumen, brillo;
    public GameObject Inventario, buzon;
    public float sliderValue;
    public Image panelBrillo;

    private const string VolumeKey = "VolumenMaestro";
    private const string BrightnessKey = "BrilloEscena";

    void Start()
    {
        can.enabled = false;
        volver.onClick.AddListener(() => Volver());
        inventario.onClick.AddListener(() => invent());
        cartas.onClick.AddListener(() => cart());

        MP = GameObject.Find("MenuPausa");
        InvenUI = GameObject.Find("InventoryPanel");

        float volumenG = PlayerPrefs.GetFloat("VolumenMaestro", 0.5f);
        volumen.value = volumenG;
        volumen.onValueChanged.AddListener(SetVolumen);
        SetVolumen(volumenG);

        brillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, brillo.value);


    }

    private void invent()
    {
        InventoryUI i = Inventario.GetComponent<InventoryUI>();
        can.enabled = false;
        i.c.enabled = true;
    }

    private void cart()
    {
        BuzónUI b = buzon.GetComponent<BuzónUI>();
        can.enabled = false;
        b.abrir();
    }


    public void SetVolumen(float v)
    {
        AudioListener.volume = v;
        PlayerPrefs.SetFloat("VolumenMaestro", v);
    }

    private void OnDestroy()
    {
        volumen.onValueChanged.RemoveListener(SetVolumen);
        
    }

    public void ChageSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("brillo", sliderValue);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, brillo.value);
    }

    public void inicio()
    {
        can.enabled = true;
    }

    private void Volver()
    {
        MenuPausaUI m = MP.GetComponent<MenuPausaUI>();
            can.enabled = false;
            m.c.enabled = true;
          
        
        
    }
}
