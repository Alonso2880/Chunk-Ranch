using UnityEngine;
using TMPro;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras; //Array de cámaras
    public TextMeshProUGUI cameraLabelText;
    private int currentCameraIndex = 0; //Contador de cámaras del array

    void Start()
    {
        ActivateCamera(currentCameraIndex);//Activa la cámara inicial
    }

    public void SwitchToNextCamera() //Función para cambiar de cámara
    {
        currentCameraIndex++; //Suma 1 al contador
        if (currentCameraIndex >= cameras.Length) 
            //Si el numero del contador es mayor al numero de cámaras en el array
        {
            currentCameraIndex = 0; //Pone el contador en el inicio
        }

        ActivateCamera(currentCameraIndex); 
        //Llama a la función ActivateCamera
    }

    void ActivateCamera(int index) //Función para activar la cámara según
        //el número del array
    {
        for (int i = 0; i < cameras.Length; i++) //Recorre el array
        {
            cameras[i].gameObject.SetActive(i == index); //Activa la cámara
        }

        if (cameraLabelText != null)
        {
            //Pone el nombre de la cámara en pantalla
            cameraLabelText.text = cameras[index].name; 
        }
    }
}