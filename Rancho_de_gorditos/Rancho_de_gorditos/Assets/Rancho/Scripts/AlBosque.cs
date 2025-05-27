using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlBosque : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                //StartCoroutine(CargarEscena("Bosque"));
                SceneManager.LoadScene("Bosque");
            }
            
        }
    }

    IEnumerator CargarEscena(string nombre)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(nombre);

        while (!operacion.isDone)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
            Debug.Log($"Progreso de cargar: {progreso * 100}%");
            yield return null;
        }
    }
}
