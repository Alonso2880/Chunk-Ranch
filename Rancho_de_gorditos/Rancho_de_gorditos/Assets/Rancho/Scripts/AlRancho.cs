using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlRancho : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                //StartCoroutine(CargarEscena("Rancho"));
                SceneManager.LoadScene("Rancho");
            }

        }
    }

    IEnumerator CargarEscena(string name)
    {
        AsyncOperation operacion = SceneManager.LoadSceneAsync(name);

        while (!operacion.isDone)
        {
            float progreso = Mathf.Clamp01(operacion.progress / 0.9f);
            Debug.Log($"Progreso de cargar: {progreso * 100}%");
            yield return null;
        }
    }
}
