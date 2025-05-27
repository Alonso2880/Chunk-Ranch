using UnityEngine;

public class Planta : MonoBehaviour
{
    public enum Tipo { Zanahoria = 1, Patata = 2, Tomate = 3, Pimiento = 4 }
    private Tipo tipo;
    private GameObject semillaPrefab;
    private GameObject brotePrefab;
    private GameObject frutoPrefab;
    private casa casaScript;

    private float ySemilla, yBrote, yFruto;
    private int etapa;
    private int diaPlantado;


    public void Inicializar(
        Tipo tipoParam,
        GameObject semilla,
        GameObject brote,
        GameObject fruto,
        casa casa,
        float offsetSemilla,
        float offsetBrote,
        float offsetFruto)
    {
        semillaPrefab = semilla;
        brotePrefab = brote;
        frutoPrefab = fruto;
        casaScript = casa;
        tipo = tipoParam;
        ySemilla = offsetSemilla;
        yBrote = offsetBrote;
        yFruto = offsetFruto;

        etapa = 0;
        diaPlantado = casaScript.dia;

        // Instanciar semilla en posición ySemilla
        transform.localPosition = new Vector3(0, ySemilla, 0);
        var go = Instantiate(semillaPrefab, transform.position, transform.rotation, transform);
        go.transform.localPosition = Vector3.zero;
        Debug.Log($"[Planta] Semilla instanciada en Y={ySemilla}");
    }

    public void ActualizarCrecimiento()
    {
        if (etapa < 2 && casaScript.dia > diaPlantado)
        {
            etapa++;
            diaPlantado = casaScript.dia;
            Debug.Log($"[Planta] Cambio a etapa {etapa}");
            CambiarModelo();
        }
    }

    private void CambiarModelo()
    {
        // Calcula el offset Y según la etapa
        float yOff = etapa == 1 ? yBrote : etapa == 2 ? yFruto : ySemilla;

        // Ajusta la posición Y del hueco padre
        Transform hueco = transform.parent;
        Vector3 posHueco = hueco.localPosition;
        posHueco.y = yOff;
        hueco.localPosition = posHueco;

        // Destruir solo los hijos del contenedor (semilla o brote previo)
        foreach (Transform child in transform)
            Destroy(child.gameObject);

        // Seleccionar el prefab según la etapa
        GameObject prefab = etapa == 1 ? brotePrefab : etapa == 2 ? frutoPrefab : null;
        Debug.Log($"[Planta] etapa={etapa}, prefab={(prefab != null ? prefab.name : "null")}");

        if (prefab != null)
        {
            // Instanciar el nuevo modelo como hijo del contenedor
            GameObject go = Instantiate(prefab, transform.position, transform.rotation, transform);
            // Ajustar su posición local a cero, ya que el contenedor está en la altura correcta
            go.transform.localPosition = Vector3.zero;
            Debug.Log($"[Planta] Modelo {prefab.name} instanciado y semilla previa destruida.");
        }
    }

    public bool EstaCrecida()
    {
        return etapa == 2;
    }

    // Devuelve el tipo de planta (zanahoria/patata) para la cosecha
    public Tipo GetTipo()
    {
        return tipo;
    }
}