using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;
public class Hechizos : MonoBehaviour
{
    public Canvas canvas;
    public Button Arriba, Abajo, Centro, Derecha, Izquierda, Arriba_Il, Abajo_Il, Central_Il, Derecha_Il, Izquierda_Il;
    private GameObject player;

    private StringBuilder combinacion;
    private const string secuenciaTomate = "12345";
    private const string secuenciaZanahoria = "54321";
    private const string secuenciaManzana = "12534"; 
    private const string secuenciaPatatas = "43521"; 
    private const string secuenciaPimientos = "32145"; 
    private const string secuenciaNaranjas = "54123";
    public bool tomate = false, zanahoria = false, manzana = false, patatas = false, pimientos = false, naranjas = false;

    
    void Start()
    {
        canvas.enabled = false;
        Arriba.onClick.AddListener(() => hechi(0));
        Abajo.onClick.AddListener(()=>hechi(1));
        Centro.onClick.AddListener(()=>hechi(2));
        Derecha.onClick.AddListener(()=>hechi(3));
        Izquierda.onClick.AddListener(()=>hechi(4));

        Arriba_Il.onClick.AddListener(()=>hechi(0));
        Abajo_Il.onClick.AddListener(() => hechi(1));
        Central_Il.onClick.AddListener(() => hechi(2));
        Derecha_Il.onClick.AddListener(() => hechi(3));
        Izquierda_Il.onClick.AddListener(() => hechi(4));

        combinacion = new StringBuilder();

        player = GameObject.Find("Player");
        Arriba_Il.GetComponent<Image>().enabled = false;
        Abajo_Il.GetComponent<Image>().enabled = false;
        Central_Il.GetComponent<Image>().enabled = false;
        Derecha_Il.GetComponent<Image>().enabled = false;
        Izquierda_Il.GetComponent <Image>().enabled = false;
    }

    private void hechi(int i)
    {
        switch (i)
        {
            case 0:
                combinacion.Append('1');
                Arriba_Il.GetComponent<Image>().enabled = true;
                break;
            case 1:
                combinacion.Append('3');
                Abajo_Il.GetComponent<Image>().enabled = true;
                break;
            case 2:
                combinacion.Append('2');
                Central_Il.GetComponent<Image>().enabled = true;
                break;
            case 3:
                combinacion.Append('5');
                Derecha_Il.GetComponent<Image>().enabled = true;
                break;
            case 4:
                combinacion.Append('4');
                Izquierda_Il.GetComponent<Image>().enabled = true;
                break;
        }
    }
    
    void Update()
    {
        //Debug.Log($"Combinación actual ({combinacion.Length}): {combinacion}");
        Hechizo h = player.GetComponent<Hechizo>();

        if(combinacion.Length == secuenciaNaranjas.Length && h.col.name == "BroteNaranja" && combinacion.ToString() == secuenciaNaranjas)
        {
                naranjas = true;
                combinacion.Clear();
                canvas.enabled = false;

            Arriba_Il.GetComponent<Image>().enabled = false;
            Abajo_Il.GetComponent<Image>().enabled = false;
            Central_Il.GetComponent<Image>().enabled = false;
            Derecha_Il.GetComponent<Image>().enabled = false;
            Izquierda_Il.GetComponent<Image>().enabled = false;
        }
        else
        { 

        if (combinacion.Length == secuenciaZanahoria.Length && h.col.name == "Zanahoria" && combinacion.ToString() == secuenciaZanahoria)
        {
                zanahoria = true;
                combinacion.Clear();
                canvas.enabled = false;
                Arriba_Il.GetComponent<Image>().enabled = false;
                Abajo_Il.GetComponent<Image>().enabled = false;
                Central_Il.GetComponent<Image>().enabled = false;
                Derecha_Il.GetComponent<Image>().enabled = false;
                Izquierda_Il.GetComponent<Image>().enabled = false;
            }
            else
            {
                if (combinacion.Length == secuenciaTomate.Length && h.col.name == "BroteTomate" && combinacion.ToString() == secuenciaTomate)
                {
                        tomate = true;
                        combinacion.Clear();
                        canvas.enabled = false;
                    Arriba_Il.GetComponent<Image>().enabled = false;
                    Abajo_Il.GetComponent<Image>().enabled = false;
                    Central_Il.GetComponent<Image>().enabled = false;
                    Derecha_Il.GetComponent<Image>().enabled = false;
                    Izquierda_Il.GetComponent<Image>().enabled = false;

                }
                else
                {
                    if (combinacion.Length == secuenciaManzana.Length && h.col.name == "BroteManzana" && combinacion.ToString() == secuenciaManzana)
                    {
                        manzana = true;
                        combinacion.Clear();
                        canvas.enabled = false;
                        Arriba_Il.GetComponent<Image>().enabled = false;
                        Abajo_Il.GetComponent<Image>().enabled = false;
                        Central_Il.GetComponent<Image>().enabled = false;
                        Derecha_Il.GetComponent<Image>().enabled = false;
                        Izquierda_Il.GetComponent<Image>().enabled = false;
                    }
                    else
                    {
                        if (combinacion.Length == secuenciaPatatas.Length && h.col.name == "Patatas" && combinacion.ToString() == secuenciaPatatas)
                        {
                            patatas = true;
                            combinacion.Clear();
                            canvas.enabled = false;
                            Arriba_Il.GetComponent<Image>().enabled = false;
                            Abajo_Il.GetComponent<Image>().enabled = false;
                            Central_Il.GetComponent<Image>().enabled = false;
                            Derecha_Il.GetComponent<Image>().enabled = false;
                            Izquierda_Il.GetComponent<Image>().enabled = false;
                        }
                        else
                        {
                            if (combinacion.Length == secuenciaPimientos.Length && h.col.name == "BrotePimiento" && combinacion.ToString() == secuenciaPimientos)
                            {
                                pimientos = true;
                                combinacion.Clear();
                                canvas.enabled = false;
                                Arriba_Il.GetComponent<Image>().enabled = false;
                                Abajo_Il.GetComponent<Image>().enabled = false;
                                Central_Il.GetComponent<Image>().enabled = false;
                                Derecha_Il.GetComponent<Image>().enabled = false;
                                Izquierda_Il.GetComponent<Image>().enabled = false;
                            }
                        }
                    }
                }
            }
        }

        if (combinacion.Length == 5)
        {
            Arriba_Il.GetComponent<Image>().enabled = false;
            Abajo_Il.GetComponent<Image>().enabled = false;
            Central_Il.GetComponent<Image>().enabled = false;
            Derecha_Il.GetComponent<Image>().enabled = false;
            Izquierda_Il.GetComponent<Image>().enabled = false;
            canvas.enabled = false;
            combinacion.Clear();
            Time.timeScale = 1;
        }
    }
}
