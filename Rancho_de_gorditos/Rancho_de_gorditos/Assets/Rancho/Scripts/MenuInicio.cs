using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicio : MonoBehaviour
{
    public Canvas Menu;
    public Button Jugar, Salir, Creditos;
    public bool menuIncio = false;
    public Image Cred;
    public AudioSource musicaRancho;
    private AudioSource musicaInicio;
    private void Awake()
    {
        Menu.enabled = true;
        Time.timeScale = 0;
        Jugar.onClick.AddListener(() => Opciones(1));
        Salir.onClick.AddListener(()=>  Opciones(2));
        Creditos.onClick.AddListener(() => Opciones(3));
        menuIncio = true;
        Cred.gameObject.SetActive(false);
        musicaInicio = GetComponent<AudioSource>();
    }

    private void Opciones(int n)
    {
        switch (n)
        {
            case 1:
                Menu.enabled = false;
                Time.timeScale = 1;
                menuIncio = false;
                musicaInicio.mute = true;
                musicaRancho.mute = false;

                break;
            case 2:
                Application.Quit();
                break;
            case 3:
                Cred.gameObject.SetActive(true);
                Jugar.gameObject.SetActive(false);
                Salir.gameObject.SetActive(false);
                if(Input.GetKeyUp(KeyCode.Escape))
                {
                    Cred.gameObject.SetActive(false);
                    Jugar.gameObject.SetActive(true);
                    Salir.gameObject.SetActive(true);
                }
                break;
        }
    }
    
    void Update()
    {
        
    }
}
