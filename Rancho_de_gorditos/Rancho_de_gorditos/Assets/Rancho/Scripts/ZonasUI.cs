using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Runtime.CompilerServices;

public class ZonasUI : MonoBehaviour
{
    public Canvas c;
    public TextMeshProUGUI Rancho;
    public TextMeshProUGUI Bosque;
    public bool rancho = false, bosque = false;
    private float tiempo = 3f;
    private bool mostrado = false;

    public AudioSource musicaRancho;
    public AudioSource musicaBosque;

    void Start()
    {
        c.enabled = false;
        Rancho.enabled = false;
        Bosque.enabled = false;
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
                 Bosque.enabled = false;
                 bosque = false;
             }
         }

     }

     private IEnumerator RanchoI(float tiempo)
     {

         c.enabled=true;
         Rancho.enabled=true;
         yield return new WaitForSeconds(tiempo);
         c.enabled=false;
         Rancho.enabled = false;
         rancho = false;
         mostrado = false;
     }

     private IEnumerator BosqueI(float tiempo)
     {
         c.enabled = true;
         Bosque.enabled=true;
         yield return new WaitForSeconds(tiempo);
         c.enabled = false;
         Bosque.enabled=false;
         bosque = false;
         mostrado = false;
     }
}
