using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Runtime.CompilerServices;

public class ZonasUI : MonoBehaviour
{
    public Canvas c;
    public Image Rancho, Bosque;
    public bool rancho = false, bosque = false;
    private float tiempo = 3f;
    private bool mostrado = false;

    public AudioSource musicaRancho;
    public AudioSource musicaBosque;

    void Start()
    {
        c.enabled = false;
        Rancho.gameObject.SetActive(false);
        Bosque.gameObject.SetActive(false);
    }


     void Update()
     {
         if (rancho && !mostrado)
         {
             mostrado = true;
            musicaRancho.mute = false;
            musicaBosque.mute = true;
            StartCoroutine(RanchoI(tiempo));
         }

         if(bosque && !mostrado)
         {
             mostrado = true;
            musicaRancho.mute = true;
            musicaBosque.mute = false;
            StartCoroutine(BosqueI(tiempo));
             if (rancho)
             {
                 StopCoroutine (BosqueI(tiempo));
                Bosque.gameObject.SetActive(false);
                bosque = false;
             }
         }

     }

     private IEnumerator RanchoI(float tiempo)
     {

         c.enabled=true;
         Rancho.gameObject.SetActive(true);
         yield return new WaitForSeconds(tiempo);
         c.enabled=false;
         Rancho.gameObject.SetActive(false);
         rancho = false;
         mostrado = false;
     }

     private IEnumerator BosqueI(float tiempo)
     {
         c.enabled = true;
         Bosque.gameObject.SetActive(true);
         yield return new WaitForSeconds(tiempo);
         c.enabled = false;
         Bosque.gameObject.SetActive(false);
         bosque = false;
         mostrado = false;
     }
}
