using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 10f;

    [Header("Rotación de cámara")]
    // Asigna aquí el objeto vacío que actuará como pivote de la cámara
    public Transform cameraPivot;
    public float mouseSensitivity = 2f;
    public float pitchMin = -45f;
    public float pitchMax = 75f;

    private float yaw = 0f;
    private float pitch = 0f;

    void Start()
    {
        if (cameraPivot == null)
            Debug.LogError("[SpaceshipController] No has asignado el Camera Pivot en el inspector.");

        // Bloquear y ocultar el cursor para control con ratón
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
    }

    void HandleMovement()
    {
        // Ejes WASD
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        // Subir y bajar con Space / LeftShift
        float up = 0f;
        if (Input.GetKey(KeyCode.Space)) up = 1f;
        else if (Input.GetKey(KeyCode.LeftShift)) up = -1f;

        // Componer dirección en local space
        Vector3 direction = transform.forward * v + transform.right * h + transform.up * up;

        // Mover la nave
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void HandleMouseLook()
    {
        // Obtener movimiento del ratón
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Acumular ángulos
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        // Rotación yaw de la nave
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        // Rotación pitch de la cámara (pivote local)
        cameraPivot.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }
}

